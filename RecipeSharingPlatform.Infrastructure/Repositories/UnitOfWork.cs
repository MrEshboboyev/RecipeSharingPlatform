﻿using RecipeSharingPlatform.Application.Common.Interfaces;
using RecipeSharingPlatform.Infrastructure.Data;

namespace RecipeSharingPlatform.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public IRecipeRepository Recipe { get; private set; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Recipe = new RecipeRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
