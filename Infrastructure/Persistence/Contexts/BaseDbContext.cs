using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        #region Properties
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<BlockedEmail> BlockedEmails { get; set; } = null!;
        #endregion
        #region Constructors
        // Constructor to initialize the DbContext with the options
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options) { }
        #endregion
        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base method
            base.OnModelCreating(modelBuilder);
            // Apply the configurations
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BlockedEmailConfiguration());
        }
        #endregion
    }
}