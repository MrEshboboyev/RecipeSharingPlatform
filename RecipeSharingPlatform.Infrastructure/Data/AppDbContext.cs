using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Domain.Entities;

namespace RecipeSharingPlatform.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // creating tables
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeLabel> RecipeLabels { get; set; }
        public DbSet<RecipeImage> RecipeImages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Relationships
            // User-Recipe Relationship (One-to-Many)
            builder.Entity<Recipe>()
                .HasOne(r => r.Chef)
                .WithMany(u => u.Recipes)
                .HasForeignKey(r => r.ChefId)
                .OnDelete(DeleteBehavior.Cascade);

            // Recipe-Label Many-to-Many Relationship
            builder.Entity<RecipeLabel>()
                .HasMany(rl => rl.Recipes)
                .WithMany(r => r.Labels)
                .UsingEntity(j => j.ToTable("RecipeRecipeLabels"));

            // Recipe-Image Relationship (One-to-Many)
            builder.Entity<RecipeImage>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.Images)
                .HasForeignKey(ri => ri.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Optional: Unique constraint on User.Alias and User.Email
            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.Alias)
            .IsUnique();

            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.Email)
                .IsUnique();
            #endregion
        }
    }
}
