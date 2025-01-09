using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MigrateMap.Bal.Extensions;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configBuilder = new ConfigurationBuilder()
                //.SetBasePath(_environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Configuration.GetValue<string>("Environment")}.json", optional: true)
                .AddEnvironmentVariables();
var configuration = configBuilder.Build();

builder.Services.AddItemServices(configuration);
// Load configuration
builder.Services.AddHttpClient();

// Configure JWT Authentication for Auth0
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
        options.Audience = builder.Configuration["Auth0:Audience"];
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = $"https://{builder.Configuration["Auth0:Domain"]}",
            ValidAudience = builder.Configuration["Auth0:Audience"]
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOriginsPolicy",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
builder.Services.AddAutoMapper(typeof(MigrateAutoMapper));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply the CORS middleware.
app.UseCors("AllowAllOriginsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
