using DataAccessLawyer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLawyer.Repository
{
    public class UserDBContext(DbContextOptions<UserDBContext> options) : DbContext(options)
    {
        public DbSet<users> User { get; set; }
        public DbSet<Corporation> Corporation { get; set; }
        public DbSet<UserCorporation> UserCorporation { get; set; }

        public DbSet<MappingDB> MappingDB { get; set; }
        public DbSet<CorpMappingDB> CorpMappingDB { get; set; }
        public DbSet<UserCorpMappingDB> UserCorpMappingDB { get; set; }
        public DbSet<MapDoc> MapDocs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MapDoc>()
                .HasKey(md => md.SqNo); // Define SqNo as the primary key
        }

    }
}
