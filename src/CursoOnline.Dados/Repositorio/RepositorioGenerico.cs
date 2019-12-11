using System.Linq;
using System.Collections.Generic;
using CursoOnline.Dominio._Base;
using CursoOnline.Dados.Contexto;

namespace CursoOnline.Dados.Repositorio
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : Entidade
    {
        protected readonly ApplicationDbContext _context;

        public RepositorioGenerico(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public void Adicionar(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public List<T> Consultar()
        {
            var entidades = _context.Set<T>().ToList();
            return entidades.Any() ? entidades : new List<T>();
        }

        public T ObterPorId(int id)
        {
            var query = _context.Set<T>().Where(entidade => entidade.Id == id);
            return query.Any() ? query.First() : null;
        }
    }
}