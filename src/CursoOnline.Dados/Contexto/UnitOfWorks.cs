using System.Threading.Tasks;
using CursoOnline.Dominio._Base;

namespace CursoOnline.Dados.Contexto
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWorks(ApplicationDbContext context)
        {
            this._context = context;

        }

        public async Task Commit()
        {
            await _context.Commit();
        }
    }
}