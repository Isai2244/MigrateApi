using MigrateMap.CrateDal;

namespace BusinessLawyer
{
    public class BaseBusiness
    {
        public async Task GetConnection()
        {
            var dal = new GenericRepository();
            await dal.GetData();
        }
    }
}
