using Microsoft.EntityFrameworkCore;
using RegisterPeople.Domain.Entitys;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RegisterPeople.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext () { }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Person> Person { get; set; }

        public DbSet<Address> Address { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    entry.Property("IsAtivo").CurrentValue = true;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("CPF").IsModified = false;
                }
            }
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // configures one-to-many relationship
            modelBuilder.Entity<Person>()
            .HasMany(e => e.Address)
            .WithOne()
            .HasForeignKey(x => x.IdPerson)
            .HasPrincipalKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
