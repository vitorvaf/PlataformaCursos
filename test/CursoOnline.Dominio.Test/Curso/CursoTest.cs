using System;
using Xunit;
using ExpectedObjects;
using CursoOnline.Dominio.Test._Util;
using CursoOnline.Dominio.Test._Builders;
using CursoOnline.Dominio.Curso;
using Xunit.Abstractions;
using Bogus;

namespace CursoOnline.Dominio.Test.Curso
{
    public class CursoTest : IDisposable
    {

        ///Histŕia de usuário
        ///Eu enquanto administrador, quero criar e editar curso para que sejam abertas para o mesmo.

        ///Critérios de aceite

        //-Criar um curso com nome, carga horaria, publico alvo, e valor de curso   
        //-As opções para o público alvo são: Estudantem Universitário, Empregado e Empreendedor
        //-Tofos os campos de curso são obrigatórios

        private readonly ITestOutputHelper _output;
        private readonly string _nome;
        private readonly int _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valor;
        private readonly string _descricao;

        public CursoTest(ITestOutputHelper _output)
        {

            var faker = new Faker();

            this._output = _output;
            this._nome = faker.Random.Word();
            this._cargaHoraria = faker.Random.Int(1,200);
            this._publicoAlvo = PublicoAlvo.Estudante;
            this._valor = faker.Random.Double(50,1000);
            this._descricao = faker.Lorem.Paragraph();            

        }

        public void Dispose()
        {
            _output.WriteLine("Dispose sendo executado");
        }



        [Fact(DisplayName = "DeveCriarCurso")]
        public void DeveCriarCurso()
        {
            //Arrange
            var cursoMock = new
            {
                Nome = "Informática Básica",
                CargaHoraria = 80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950

            };

            //Act
            var curso = new Dominio.Curso.Curso(cursoMock.Nome,
                                  cursoMock.CargaHoraria,
                                  cursoMock.PublicoAlvo,
                                  cursoMock.Valor);

            //Assert
            cursoMock.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveNomeSerInvalido(string nomeInvalido)
        {           

            //Assert
            Assert.Throws<ArgumentException>(() =>
             CursoBuilder.Novo().ComNome(nomeInvalido).Build()).ComMensagem("Nome inválido");

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-222)]
        public void NaoDeveCursoTerCargaHorariaMenorQue1(int cargaHorariaInvalida)
        {            
            //Assert
            Assert.Throws<ArgumentException>(() =>
             CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build()).ComMensagem("Carga horária inválida");

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-222)]
        public void NaoDeveCursoTerValorMenorQue1(double valorInvalido)
        {           
            //Assert
            Assert.Throws<ArgumentException>(() =>
             CursoBuilder.Novo().ComValor(valorInvalido).Build()).ComMensagem("Valor inválido");
        }

    }
  
}