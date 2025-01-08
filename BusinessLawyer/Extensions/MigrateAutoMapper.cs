using AutoMapper;
using DataAccessLawyer.Models;
using MigrateMap.Bal.Models.Request;
using MigrateMap.Bal.Models.Response;

namespace MigrateMap.Bal.Extensions
{
    public class MigrateAutoMapper : Profile
    {
        public MigrateAutoMapper()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Corporation, CorporationResponse>()
                .ForMember(dest => dest.CorporationId, act => act.MapFrom(src => src.corporationid))
                //Provide Mapping Dept of FullName and Department Property
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.name))
                .ForMember(dest => dest.Description, act => act.MapFrom(src => src.description)).ReverseMap();

            CreateMap<MappingDB, MappingDBResponse>()
                .ForMember(dest => dest.MappingdbId, act => act.MapFrom(src => src.mappingdbid ))
                //Provide Mapping Dept of FullName and Department Property
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.name))
                .ForMember(dest => dest.Description, act => act.MapFrom(src => src.description))
                .ReverseMap();

            // MapDocRequest to MapDoc Mapping
            CreateMap<MapDocRequest, MapDoc>()
                .ForMember(dest => dest.SqNo, opt => opt.Ignore()); // Ignore primary key during updates

            // MapDoc to MapDocResponse Mapping
            CreateMap<MapDoc, MapDocResponse>();

            // MapDocResponse to MapDoc Mapping
            CreateMap<MapDocResponse, MapDoc>();
        }
    }
}
