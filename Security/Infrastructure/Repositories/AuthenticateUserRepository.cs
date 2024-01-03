using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class AuthenticateUserRepository : RepositoryBase<AuthenticateUser>, IAuthenticateUserRepository
    {
        public AuthenticateUserRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
