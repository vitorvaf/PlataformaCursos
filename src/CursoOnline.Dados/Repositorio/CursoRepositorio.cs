using System.Linq;
using System.Collections.Generic;
using CursoOnline.Dominio.Curso;
using CursoOnline.Dominio._Base;
using CursoOnline.Dados.Contexto;

namespace CursoOnline.Dados.Repositorio
{
    public class CursoRepositorio : RepositorioGenerico<Curso>, ICursoRepositorio
    {
        public CursoRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public Curso ObterPeloNome(string nome)
        {
            var entidade = _context.Set<Curso>().Where(c => c.Nome.ToLower().Contains(nome.ToLower()));
            if(entidade.Any())
                return entidade.First();

                return null;
        }
    }
}