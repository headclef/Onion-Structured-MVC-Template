using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        #region Methods
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            // Additions to the UserConfiguration class
        }
        #endregion
    }
}