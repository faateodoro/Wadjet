using Microsoft.EntityFrameworkCore;
using Wadjet.Entities;

namespace Wadjet.Infra;

public class ApplicationContext : DbContext
{

    public DbSet<Establishment> Establishments { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }
}
