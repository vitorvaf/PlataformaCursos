namespace CursoOnline.Dominio.Curso
{
    public  class CursoDTO
    {
        public CursoDTO()
        {
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CargaHoraria { get; set; }
        public string PublicoAlvo { get; set; }
        public double Valor { get; set; }
    }
}