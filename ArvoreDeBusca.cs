using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arvore
{
    public class ArvoreDeBusca<Tipo> : IComparable<Tipo>
        where Tipo : IComparable<Tipo>
    {
        public NoArvore<Tipo> raiz, atual, antecessor;

        public Panel painelArvore;

        public Panel OndeExibir
        {
            get { return painelArvore; }
            set { painelArvore = value; }
        }

        public int CompareTo(Tipo o)
        {
            return atual.dados.CompareTo(o);
        }

        public int CompareTo(NoArvore<Tipo> o)
        {
            return atual.dados.CompareTo(o.dados);
        }

        public int alturaArvore(NoArvore<Tipo> atual, ref bool balanceada)
        {
            int alturaDireita, alturaEsquerda, result;
            if (atual != null && balanceada)
            {
                alturaDireita = 1 + alturaArvore(atual.dir, ref balanceada);
                alturaEsquerda = 1 + alturaArvore(atual.esq, ref balanceada);
                if (alturaDireita > alturaEsquerda)
                    result = alturaDireita;
                else
                    result = alturaEsquerda;
                if (Math.Abs(alturaDireita - alturaEsquerda) > 1)
                    balanceada = false;
            }
            else
                result = 0;
            return result;
        }


        public int getAltura(NoArvore<Tipo> no)
        {
            if (no != null)
                return no.altura;
            else
                return -1;
        }

        public NoArvore<Tipo> Insert(Tipo item, NoArvore<Tipo> n)
        {
            if (n == null)
                n = new NoArvore<Tipo>(item);	// atributo altura valerá 0!
            else
            {
                if (item.CompareTo(n.dados) < 0)
                {
                    n.esq = Insert(item, n.esq);
                    if (getAltura(n.esq) - getAltura(n.dir) == 2)  // o método getAltura testa nulo!
                        if (item.CompareTo(n.esq.dados) < 0)
                            n = RotateWithLeftChild(n);
                        else
                            n = DoubleWithLeftChild(n);
                }
                else
                    if (item.CompareTo(n.dados) > 0)
                    {
                        n.dir = Insert(item, n.dir);
                        if (getAltura(n.dir) - getAltura(n.esq) == 2)  // o método get Altura testa nulo!
                            if (item.CompareTo(n.dir.dados) > 0)
                                n = RotateWithRightChild(n);
                            else
                                n = DoubleWithRightChild(n);
                    }
                //else ; - não faz nada, valor duplicado

                n.altura = Math.Max(getAltura(n.esq), getAltura(n.dir)) + 1;
            }
            return n;
        }

        private NoArvore<Tipo> RotateWithLeftChild(NoArvore<Tipo> no)
        {
            NoArvore<Tipo> temp = no;  // apenas para declarar

            temp = no.esq;
            no.esq = temp.dir;
            temp.dir = no;
            no.altura = Math.Max(getAltura(no.esq), getAltura(no.dir)) + 1;
            temp.altura = Math.Max(getAltura(temp.esq), getAltura(no)) + 1;
            //System.Threading.Thread.Sleep(2000);
            MessageBox.Show("Rotação à direita do nó " + temp.dados.ToString());
            Form1.ActiveForm.Invalidate();
            Application.DoEvents();
            return temp;
        }

        private NoArvore<Tipo> RotateWithRightChild(NoArvore<Tipo> no)
        {
            NoArvore<Tipo> temp = no;  // apenas para declarar

            temp = no.dir;
            no.dir = temp.esq;
            temp.esq = no;
            no.altura = Math.Max(getAltura(no.esq), getAltura(no.dir)) + 1;
            temp.altura = Math.Max(getAltura(temp.dir), getAltura(no)) + 1;
            //System.Threading.Thread.Sleep(2000);
            MessageBox.Show("Rotação à esquerda do nó " + temp.dados.ToString());
            Form1.ActiveForm.Invalidate();
            Application.DoEvents();
            return temp;
        }

        private NoArvore<Tipo> DoubleWithLeftChild(NoArvore<Tipo> no)
        {
            MessageBox.Show("Rotação dupla à direita do nó " + no.dados.ToString());
            no.esq = RotateWithRightChild(no.esq);
            Form1.ActiveForm.Invalidate();
            Application.DoEvents();
            return RotateWithLeftChild(no);
        }

        private NoArvore<Tipo> DoubleWithRightChild(NoArvore<Tipo> no)
        {
            MessageBox.Show("Rotação dupla à esquerda do nó " + no.dados.ToString());
            no.dir = RotateWithLeftChild(no.dir);
            Form1.ActiveForm.Invalidate();
            Application.DoEvents();
            return RotateWithRightChild(no);
        }

    }
}