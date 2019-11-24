using System;
using Xunit;

namespace CursoOnline.Dominio.Test
{
    public class MeuPrimeiroTeste
    {
        [Fact(DisplayName = "SeValorDasVariaveisSaoIguais")]
        public void SeValorDasVariaveisSaoIguais()
        {   
            
            //Arrange
            int variavel1 = 2;
            int variavel2 = 2;

            ///Act

            ///Assert
            Assert.Equal(variavel1, variavel2);


        }
    }
}
