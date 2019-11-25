namespace CursoOnline.Dominio.Curso
{
    public interface ICursoRepository
    {
        void Adicionar(Dominio.Curso.Curso curso);
        Dominio.Curso.Curso ObterPeloNome(string nome);
    }
}