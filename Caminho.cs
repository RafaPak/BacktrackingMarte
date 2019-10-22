using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    // Classe de Caminho, para guardar todos os caminhos entre as cidades de Marte e seus respectivos atributos
    public class Caminho : IComparable<Caminho>
    {
        private int idCidadeOrigem, idCidadeDestino;
        private int distancia, tempo, custo;

        public Caminho(int idCO, int idCD, int d, int t, int c)
        {
            this.idCidadeOrigem = idCO;
            this.idCidadeDestino = idCD;
            this.distancia = d;
            this.tempo = t;
            this.custo = c;
        }

        // Construtor reservado para a procura de caminhos possíveis, no Evento Click do Botão Buscar, em que só são guardadas
        // informações que serão utilizadas no algoritmo do Formulario.
        public Caminho(int idOrigem, int idDestino, int d)
        {
            this.idCidadeOrigem = idOrigem;
            this.idCidadeDestino = idDestino;
            this.distancia = d;
        }

        public int IdCidadeOrigem { get => idCidadeOrigem; set => idCidadeOrigem = value; }
        public int IdCidadeDestino { get => idCidadeDestino; set => idCidadeDestino = value; }
        public int Distancia { get => distancia; set => distancia = value; }
        public int Tempo { get => tempo; set => tempo = value; }
        public int Custo { get => custo; set => custo = value; }

        public int CompareTo (Caminho other)
        {
            return this.custo.CompareTo(other.custo);
        }

        public override string ToString()
        {
            return $"{idCidadeOrigem}";
        }
    }
}
