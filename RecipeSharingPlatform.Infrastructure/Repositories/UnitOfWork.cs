using RecipeSharingPlatform.Application.Common.Interfaces;
using RecipeSharingPlatform.Infrastructure.Data;

namespace RecipeSharingPlatform.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
