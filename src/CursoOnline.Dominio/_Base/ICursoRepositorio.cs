
namespace CursoOnline.Dominio._Base
{
    public interface ICursoRepositorio : IRepositorioGenerico<Curso.Curso>
    {
        Curso.Curso ObterPeloNome(string nome);         
    }
}