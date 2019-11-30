using Microsoft.EntityFrameworkCore;
using CursoOnline.Dominio.Curso;
using System.Threading.Tasks;

namespace CursoOnline.Dados.Contexto
{
    public class ApplicattionContext : DbContext
    {

        public ApplicattionContext(DbContextOptions<ApplicattionContext> options) :base(options)
        {
            
        }

        public DbSet<Curso> Cursos {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
        
    }
}