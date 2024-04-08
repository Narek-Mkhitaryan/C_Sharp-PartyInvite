using Microsoft.EntityFrameworkCore;
using UFAR.NM.API.Models.Entites;

namespace UFAR.NM.API.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<Invations> Invitors { get; set; }
    }
}
