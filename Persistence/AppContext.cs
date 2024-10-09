using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Persistence
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EmailAppUser> Users { get; set; }
        public DbSet<Email> Emails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableProperty property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string)))
            {
                if (property.GetMaxLength() == null)
                    property.SetMaxLength(256);
            }
        }
    }
}
