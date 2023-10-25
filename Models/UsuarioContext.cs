using Microsoft.EntityFrameworkCore;

namespace Stefanini_Project01.Models
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) 
            : base(options) 
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } = null!;
    }
}