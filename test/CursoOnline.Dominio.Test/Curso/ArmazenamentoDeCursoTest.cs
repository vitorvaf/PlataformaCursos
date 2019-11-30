using System;
using Xunit;
using CursoOnline.Dominio.Curso;
using Moq;
using Bogus;
using CursoOnline.Dominio.Test._Util;
using CursoOnline.Dominio.Test._Builders;

namespace CursoOnline.Dominio.Test.Curso
{
    public class ArmazenamentoDeCursoTest
    {
        private readonly CursoDTO _cursoDTO;
        public Mock<ICursoRepository> _cursoRepositoryMock { get; private set; }
        internal ArmazenamentoDeCurso _armazenadorCurso { get; private set; }

        public ArmazenamentoDeCursoTest()
        {

            _cursoRepositoryMock = new Mock<ICursoRepository>();
            _armazenadorCurso = new ArmazenamentoDeCurso(_cursoRepositoryMock.Object);

            var faker = new Faker();

            _cursoDTO = new CursoDTO()
            {
                Nome = faker.Random.Words(),
                Descricao = faker.Lorem.Paragraph(),
                CargaHoraria = faker.Random.Int(50, 1000),
                PublicoAlvo = "Estudante",
                Valor = faker.Random.Int(1, 200)
            };

        }


        [Fact]
        public void DeveAdicionarCurso()
        {
            //Act
            _armazenadorCurso.Armazenar(_cursoDTO);

            //Assert
            _cursoRepositoryMock.Verify(c => c.Adicionar(
                It.Is<Dominio.Curso.Curso>(r => 
                    r.Nome == _cursoDTO.Nome)));

        }

        [Fact(DisplayName = "NaoDeveAdicionarCursoComNomeJaSalvo")]
        public void NaoDeveAdicionarCursoComNomeJaSalvo()
        {
            //Arrange
            var cursoSalvo = CursoBuilder.Novo().ComNome(_cursoDTO.Nome).Build();            

            //Act
            _cursoRepositoryMock.Setup(r=> r.ObterPeloNome(_cursoDTO.Nome)).Returns(cursoSalvo);

            //Assert
            Assert.Throws<ArgumentException>(()=> _armazenadorCurso.Armazenar(_cursoDTO))
                .ComMensagem("Nome do curso já consta no banco de dados");
        }


        [Fact]
        public void NaoDeveInformarPublicoAlvoInvalido()
        {
            //Arrange
            string publicoAlvoInvalido = "Medico";
            _cursoDTO.PublicoAlvo = publicoAlvoInvalido;

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => _armazenadorCurso.Armazenar(_cursoDTO))
                .ComMensagem("Público alvo inválido");
        }


    }   
}