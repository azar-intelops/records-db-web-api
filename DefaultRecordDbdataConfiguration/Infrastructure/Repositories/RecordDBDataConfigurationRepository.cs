using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class RecordDBDataConfigurationRepository : RepositoryBase<RecordDBDataConfiguration>, IRecordDBDataConfigurationRepository
    {
        public RecordDBDataConfigurationRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
