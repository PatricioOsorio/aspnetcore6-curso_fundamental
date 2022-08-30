using CursoFundamental.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoFundamental.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
    }

    // Usar modelos
    public DbSet<User> User { get; set; }
  }
}
