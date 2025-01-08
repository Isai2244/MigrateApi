using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccessLawyer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICorpMappingDBRepository CorpMappingDB { get; }
        ICorporationRepository Corporation{ get; }
        IMappingDBRepository MappingDB{ get; }
        IUserCorpMappingDBRepository UserCorpMappingDB { get; }
        IUserCorporationRepository UserCorporation { get; }
        IUsersRepository Users { get; }
        IMapDocRepository MapDoc { get; }
        int Save();
        Task<int> SaveAsync();
        IDbContextTransaction BeginTran();
    }
}
