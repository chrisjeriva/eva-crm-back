using Microsoft.EntityFrameworkCore;
using Prospectos.Models;

namespace Prospectos.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Prospecto> Prospectos { get; set; }
        public DbSet<Estatus> Estatus { get; set; }

        public DbSet<DocumentoProspecto> DocumentosProspectos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Authority> Authorities{ get; set; }
    }
}
