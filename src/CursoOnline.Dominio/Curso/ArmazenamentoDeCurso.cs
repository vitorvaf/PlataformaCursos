using System;

namespace CursoOnline.Dominio.Curso
{
    public  class ArmazenamentoDeCurso
    {
        private readonly ICursoRepository _cursoRepository;


        public ArmazenamentoDeCurso(ICursoRepository cursoRepository)
        {
            this._cursoRepository = cursoRepository;
        }

        public void Armazenar(CursoDTO cursoDTO)
        {
            var cursoJaSalvo = _cursoRepository.ObterPeloNome(cursoDTO.Nome);

            if(cursoJaSalvo != null)
                throw new ArgumentException("Nome do curso já consta no banco de dados");
            
            if(!Enum.TryParse<PublicoAlvo>(cursoDTO.PublicoAlvo, out var publicoAlvo))            
                throw new ArgumentException("Público alvo inválido");


            var novoCurso = new CursoOnline.Dominio.Curso.Curso(cursoDTO.Nome,
                                                                cursoDTO.CargaHoraria,
                                                                (PublicoAlvo)publicoAlvo,
                                                                cursoDTO.Valor);
            _cursoRepository.Adicionar(novoCurso);
        }
    }
    
}