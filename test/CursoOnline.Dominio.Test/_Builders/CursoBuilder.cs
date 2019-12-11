using System;
using CursoOnline.Dominio.Test.Curso;
using CursoOnline.Dominio.Curso;


namespace CursoOnline.Dominio.Test._Builders
{
    public class CursoBuilder
    {

        
        private string _nome = "Informática básica";
        private string _descricao = "Uma descriçao";
        private int _cargaHoraria = 80;
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
        private double _valor = 950;
       

        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }

        public  CursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public  CursoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public CursoBuilder ComCargaHoraria(int cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
            
        }

        public CursoBuilder ComValor(double valor)
        {
            _valor = valor;
            return this;
        }


        public Dominio.Curso.Curso Build()
        {
            return new Dominio.Curso.Curso(_nome,_cargaHoraria, _descricao, _publicoAlvo,_valor);
        }


        
    }
}