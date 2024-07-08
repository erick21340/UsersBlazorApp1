using Microsoft.EntityFrameworkCore;

namespace UsersBlazorApp.API.Context
{
    public class ContextFactory : IDbContextFactory<UsersDbContext>
    {
        private readonly DbContextOptions<UsersDbContext> _options;

        public ContextFactory(DbContextOptions<UsersDbContext> options)
        {
            _options = options;
        }

        public UsersDbContext CreateDbContext()
        {
            return new UsersDbContext(_options);
        }
    }
}
