using Microsoft.EntityFrameworkCore;
using EstudosAPI.Model;
using Npgsql;
namespace EstudosAPI.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=Teste; User Id=postgres; Password=softlog");

    }
}

