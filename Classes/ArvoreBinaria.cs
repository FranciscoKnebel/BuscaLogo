using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
            string s = "";
            Arvore a = new Arvore(10);
            a.Insere(5);
            a.Insere(7);
            a.Insere(12);
            a.Imprime(null, ref s);
            MessageBox.Show(s);
            //Output: 5 7 10 12
 */

namespace BuscaLogo.Classes
{
        class Nodo
        {
            public int valor;
            public Nodo esquerda;
            public Nodo direita;

            public Nodo(int inicial)    // construtor para árvore apenas com a raiz
            {
                valor = inicial;
                esquerda = null;
                direita = null;
            }
        }

        class Arvore
        {
            Nodo raiz;

            /// <summary>
            /// Cria uma árvore binária com raiz nula.
            /// </summary>    
            public Arvore()
            {
                raiz = null;
            }

            /// <summary>
            /// Cria uma árvore binária com raiz possuindo um valor.
            /// </summary>
            /// <param name="value"></param>
            public Arvore(int value)
            {
                raiz = new Nodo(value);
            }

            /// <summary>
            /// Insere um valor na árvore binária, de forma recursiva.
            /// </summary>
            /// <param name="value"></param>
            public void Insere(int value)
            {
                InsereRC(ref raiz, value);
            }

            private void InsereRC(ref Nodo N, int value)
            {
                if (N == null)
                {
                    Nodo novoNodo = new Nodo(value);
                    N = novoNodo;
                }
                else if (value < N.valor) // menor vai pra esquerda
                    InsereRC(ref N.esquerda, value);
                else //if (value >= N.valor) // maior ou igual vai pra direita
                    InsereRC(ref N.direita, value);

                return;
            }

            public void Imprime(Nodo N, ref string s)
            {
                if (N == null)
                    N = raiz;

                if (N.esquerda != null)
                {
                    Imprime(N.esquerda, ref s);
                    s = s + N.valor.ToString().PadLeft(3);
                }
                else
                    s = s + N.valor.ToString().PadLeft(3);

                if(N.direita != null)
                    Imprime(N.direita, ref s);
            }

            /// <summary>
            /// Gera uma árvore, com n valores aleatórios, de valores possiveís min até max.
            /// Retorna string com os valores ordenados.
            /// </summary>
            /// <param name="n"></param>
            /// <param name="min"></param>
            /// <param name="max"></param>
            /// <returns></returns>
            public string RND(int n, int min, int max)
            {
                Arvore Tree;
                Random rnd = new Random();
                int num;
                string sorted = "";

                num = rnd.Next(min, max);
                Tree = new Arvore(num);
                for(int i = 1; i < n; i++)
                {
                    num = rnd.Next(min, max);
                    Tree.Insere(num);
                }
                Tree.Imprime(null, ref sorted);

                return sorted;
            }

        }




}
