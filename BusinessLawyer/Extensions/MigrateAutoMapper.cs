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

            CreateMap<MapDocRequest, MapDoc>()
                .ForMember(dest => dest.SqNo, opt => opt.MapFrom(src => src.SqNo == 0 ? (int?)null : src.SqNo)) // Handle SqNo as nullable
                .ForMember(dest => dest.ReusableLogicYN, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.ReusableLogicYN) ? "N" : src.ReusableLogicYN)) // Validate reusable_logic_y_n
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt ?? DateTime.UtcNow)) // Default UpdatedAt
                .ForMember(dest => dest.MandatoryFieldS4, opt => opt.MapFrom(src => Truncate(src.MandatoryFieldS4, 50))) // Handle max length
                .ForMember(dest => dest.InScopeForAuping, opt => opt.MapFrom(src => Truncate(src.InScopeForAuping, 50)))
                .ForMember(dest => dest.FieldType, opt => opt.MapFrom(src => Truncate(src.FieldType, 50)))
                .ForMember(dest => dest.SourceDataType, opt => opt.MapFrom(src => Truncate(src.SourceDataType, 50)))
                .ForAllMembers(opt => opt.MapFrom(src => src)); // Map all other fields directly

            // MapDoc to MapDocResponse (for returning to the client)
            CreateMap<MapDoc, MapDocResponse>().ReverseMap();
            CreateMap<MapDocResponse, MapDoc>();

        }

        // Utility method for truncating string values
        private static string Truncate(string value, int maxLength)
        {
            return string.IsNullOrEmpty(value) ? null : value.Length > maxLength ? value.Substring(0, maxLength) : value;
        }

    }
}
