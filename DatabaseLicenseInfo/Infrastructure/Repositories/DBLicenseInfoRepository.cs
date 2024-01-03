using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class DBLicenseInfoRepository : RepositoryBase<DBLicenseInfo>, IDBLicenseInfoRepository
    {
        public DBLicenseInfoRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
