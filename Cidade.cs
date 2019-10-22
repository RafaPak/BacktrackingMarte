using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    // Classe de Cidade, para guardar todas as cidades de Marte e seus respectivos atributos
    public class Cidade : IComparable<Cidade>
    {
        private int idCidade;
        private string nome;
        private int coordX, coordY;

        public Cidade(int id, string n, int x, int y)
        {
            this.idCidade = id;
            this.nome = n;
            this.coordX = x;
            this.coordY = y;
        }

        // Construtor utilizado para método de Procura de Cidade de acordo com o ID, desenvolvido no Formulário do Projeto
        public Cidade(int id)
        {
            this.idCidade = id;
            this.nome = "";
            this.coordX = 0;
            this.coordY = 0;
        }

        public int IdCidade { get => idCidade; set => idCidade = value; }
        public string Nome { get => nome; set => nome = value; }
        public int CoordX { get => coordX; set => coordX = value; }
        public int CoordY { get => coordY; set => coordY = value; }

        public int CompareTo(Cidade other)
        {
            return this.idCidade.CompareTo(other.idCidade);
        }

        public override string ToString()
        {
            return $"{idCidade: 00} - {nome}";
        }
    }
}
