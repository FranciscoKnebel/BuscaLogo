using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tweetinvi.Core.Interfaces;


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
            public ITweet valor;
            public Nodo esquerda;
            public Nodo direita;

            public Nodo(ITweet inicial)    // construtor para árvore apenas com a raiz
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
            public Arvore(ITweet value)
            {
                raiz = new Nodo(value);
            }

            /// <summary>
            /// Insere um valor na árvore binária, de forma recursiva.
            /// </summary>
            /// <param name="value"></param>
            public void Insere(ITweet value)
            {
                InsereRC(ref raiz, value);
            }

            private void InsereRC(ref Nodo N, ITweet value)
            {
                if (N == null)
                {
                    Nodo novoNodo = new Nodo(value);
                    N = novoNodo;
                }
                else if (value.CreatedAt < N.valor.CreatedAt) // menor vai pra esquerda
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
                    s = s + N.valor.CreatedBy.ScreenName + "\n";
                }
                else
                    s = s + N.valor.CreatedBy.ScreenName + "\n";

                if(N.direita != null)
                    Imprime(N.direita, ref s);
            }
        }
}
