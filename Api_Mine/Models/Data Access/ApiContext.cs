using Microsoft.EntityFrameworkCore;

namespace Api_Mine.Models.Data_Access
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            Database.Migrate();
            this.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<DrillBlockPointsDatabaseModel>()
                .HasMany(p => p.Sequence)
                .WithOne(c => c.DrillBlockPointsDatabaseModel)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DrillBlockDatabaseModel>()
                .HasMany<DrillBlockPointsDatabaseModel>()
                .WithOne(p => p.DrillBlockDatabaseModel)
                .HasForeignKey(p => p.DrillBlockId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DrillBlockDatabaseModel>()
                .HasMany<HoleDatabaseModel>()
                .WithOne(p => p.DrillBlockDatabaseModel)
                .HasForeignKey(p => p.DrillBlockDatabaseModelId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HoleDatabaseModel>()
                .HasMany<HolePointsDatabaseModel>()
                .WithOne(p => p.HoleDatabaseModel)
                .HasForeignKey(p => p.HoleId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<DrillBlockDatabaseModel> DrillBlockDatabaseModels { get; set; }
        public DbSet<DrillBlockPointsDatabaseModel> DrillBlockPointsDatabaseModels { get; set; }
        public DbSet<HoleDatabaseModel> HoleDatabaseModels { get; set; }
        public DbSet<HolePointsDatabaseModel> HolePointsDatabaseModels { get; set; }
    }
}
