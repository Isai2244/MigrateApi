using AutoMapper;
using DataAccessLawyer.Interfaces;
using DataAccessLawyer.Models;
using MigrateMap.Bal.Interfaces;
using MigrateMap.Bal.Models.Response;

namespace MigrateMap.Bal.Implementation
{
    public class AdminService : IAdminService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AdminService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        

    }
}
