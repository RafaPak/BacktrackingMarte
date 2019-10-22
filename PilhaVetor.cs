using apCaminhosMarte;
using System;

public class PilhaVetor<Dado> : IStack<Dado> where Dado : IComparable<Dado>
{
    Dado[] P;
    int topo;

    int posicoes;

    const int MAXIMO = 500;

    public PilhaVetor(int posic)
    {
        posicoes = posic;
        P = new Dado[posicoes];
        topo = -1;
    }

    public PilhaVetor() : this(MAXIMO)
    {
    }

    public void Empilhar(Dado elemento)
    {
        if (Tamanho() == posicoes)
            throw new PilhaCheiaException("Overflow - pilha cheia");

        topo++;
        P[topo] = elemento;
    }

    public Dado Desempilhar()
    {
        if (EstaVazia())
            throw new PilhaVaziaException("Underflow - pilha vazia");

        Dado elemento = P[topo];
        P[topo] = default(Dado);
        topo--;
        return elemento;
    }

    public Dado OTopo()
    {
        if (EstaVazia())
            throw new PilhaVaziaException("Underflow - pilha vazia");

        Dado elemento = P[topo];
        return elemento;
    }

    public bool EstaVazia()
    {
        return topo < 0;
    }

    public int Tamanho()
    {
        return topo + 1;
    }

    // Método Copia, adaptado da correção da prova, utilizado no Projeto no Evento Click do botão Busca, na busca de caminhos,
    // para armazenar todos os caminhos numa pilha auxiliar que não altere a pilha original ou a afete,
    // deixando-a intacta para múltiplos usos.
    public PilhaVetor<Dado> Copia()
    {
        PilhaVetor<Dado> retPilha = new PilhaVetor<Dado>();
        PilhaVetor<Dado> aux = new PilhaVetor<Dado>();
        Dado temp;

        while (!this.EstaVazia())
            aux.Empilhar(this.Desempilhar());

        while (!aux.EstaVazia())
        {
            temp = aux.Desempilhar();
            this.Empilhar(temp);
            retPilha.Empilhar(temp);
        }
        return retPilha;
    }
}
