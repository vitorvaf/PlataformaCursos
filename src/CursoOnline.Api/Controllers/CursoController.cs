using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CursoOnline.Dominio.Curso;
using CursoOnline.Dominio._Base;

namespace CursoOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {

        private readonly ArmazenadorDeCurso _armazenador;
        private readonly IRepositorioGenerico<Curso> _repositorio;

        public CursoController(ArmazenadorDeCurso armazenador, IRepositorioGenerico<Curso> repositorio)
        {
            this._repositorio = repositorio;
            this._armazenador = armazenador;

        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {         
            
            var cursos = _repositorio.Consultar();

            if(cursos.Any())
            {
                 var listaDto = cursos.Select(c => new CursoParaListagemDto {
                     Id = c.Id,
                     Nome = c.Nome,
                     CargaHoraria = c.CargaHoraria,
                     PublicoAlvo = c.PublicoAlvo.ToString(),
                     Valor = c.Valor
                 });

                 return Ok(listaDto);
            }           
            
            return Ok();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var curso = _repositorio.ObterPorId(id);
            return Ok(curso);

        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] CursoDTO novoCurso)
        {
            _armazenador.Armazenar(novoCurso);
            return Ok(novoCurso);
        }


    }
}
