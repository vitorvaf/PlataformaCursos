using System;

namespace CursoOnline.Dominio.Curso
{
     public enum PublicoAlvo
    {
        Estudante,
        Universitário,
        Empregado,
        Empreendedor
    }

    public class Curso
    {

        public string Nome { get; private set; }

        public string Descricao { get; private set; }
        public int CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }

        public Curso(string nome, int cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inválido");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga horária inválida");


            if (valor < 1)
                throw new ArgumentException("Valor inválido");


            this.Valor = valor;
            this.PublicoAlvo = publicoAlvo;
            this.CargaHoraria = cargaHoraria;
            this.Nome = nome;
        }
    }
}