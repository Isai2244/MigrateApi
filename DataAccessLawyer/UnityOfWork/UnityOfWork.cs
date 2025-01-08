using DataAccessLawyer.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccessLawyer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserDBContext _context;
        public UnitOfWork(UserDBContext context, ICorpMappingDBRepository corpMappingDB, ICorporationRepository corporation,
            IMappingDBRepository mappingDB,IMapDocRepository MapDoc, IUserCorpMappingDBRepository userCorpMappingDB, IUserCorporationRepository userCorporation,
            IUsersRepository user)
        {
            this._context = context;
            this.CorpMappingDB= corpMappingDB;
            this.Corporation= corporation;
            this.MappingDB= mappingDB;
            this.UserCorpMappingDB= userCorpMappingDB;
            this.Users = user;
            this.MapDoc= MapDoc;
        }
        public ICorpMappingDBRepository CorpMappingDB { get; private set; }
        public ICorporationRepository Corporation { get; private set; }
        public IMapDocRepository MapDoc { get; private set; }
        public IMappingDBRepository MappingDB { get; private set; }
        public IUserCorpMappingDBRepository UserCorpMappingDB { get; private set; }
        public IUserCorporationRepository UserCorporation { get; private set; }
        public IUsersRepository Users { get; private set; }
        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync() // Implement the async save method
        {
            return await _context.SaveChangesAsync();
        }
        public IDbContextTransaction BeginTran()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
