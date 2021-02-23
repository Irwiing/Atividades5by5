using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PListaDinSimEnc
{
    class ListaContatos
    {
        public Pessoa Head { get; set; }
        public Pessoa Tail { get; set; }
        public int Cont { get; set; }
        public bool Vazia()
        {
            if ((Head == null) && (Tail == null))
                return true;
            return false;
        }

        public void Push(Pessoa aux)
        {
            if (Vazia())
            {
                Head = aux;
                Tail = aux;
                Cont++;
                Console.WriteLine("Inseriu com Lista Vazia!");
            }
            else
            {
                if (aux.Nome.CompareTo(Tail.Nome) >= 0) // Inserir novo "último" elemento
                {
                    Tail.Proximo = aux;
                    Tail = aux;
                    Cont++;
                    Console.WriteLine("Inseriu no Final da lista!");
                }
                else
                {
                    if (aux.Nome.CompareTo(Head.Nome) < 0)// Inserir novo "primeiro" elemento
                    {
                        aux.Proximo = Head;
                        Head = aux;
                        Cont++;
                        Console.WriteLine("Inseriu no Inicio da lista!");
                    }
                    else // Inserir no "meio" da Lista
                    {
                        Pessoa aux1 = Head;
                        do
                        {
                            if (aux.Nome.CompareTo(aux1.Proximo.Nome) < 0)
                            {
                                aux.Proximo = aux1.Proximo;
                                aux1.Proximo = aux;
                                Console.WriteLine("Inseriu no \"meio\" da lista!");
                                Cont++;
                                break;
                            }
                            aux1 = aux1.Proximo;
                        } while (true);
                    }
                }
            }
        }
        public void Pop(Pessoa pessoa)
        {
            if (Vazia())
            {
                Console.WriteLine("Lista Vazia!");
                return;
            }

            Pessoa aux = Head;
            Pessoa aux2 = aux.Proximo;
            do
            {
                if (Head.Nome == pessoa.Nome)
                {
                    Head = aux2;
                    if (aux == Tail)
                        Tail = Head;
                    return;
                }
                if(aux2.Nome == pessoa.Nome)
                {
                    if(aux2 == Tail)
                    {                        
                        Tail = aux;
                        Tail.Proximo = null;
                        return;
                    }
                    aux.Proximo = aux2.Proximo;
                    return;
                }
                aux = aux2;
                aux2 = aux2.Proximo;
            } while (aux2 != null);
        }
        public void PrintPessoa(Pessoa pessoa)
        {
            if (Vazia())
            {
                Console.WriteLine("Lista Vazia!");
                return;
            }

            Pessoa aux = Head;
            do
            {
                if (pessoa.Nome == aux.Nome)
                {
                    Console.WriteLine(aux.ToString());
                    return;
                }
                aux = aux.Proximo;
            } while (true);
        }
        public void Print()
        {
            if (Vazia())
            {
                Console.WriteLine("Impossível Imprimir! Lista vazia!");
                Console.ReadKey();
            }
            else
            {
                Pessoa aux = Head;
                Console.WriteLine("\n>>> CONTATOS NA LISTA <<<\n");
                do
                {
                    Console.WriteLine(aux.ToString());
                    aux = aux.Proximo;
                } while (aux != null);
                Console.WriteLine("\n>>> FIM <<<");
            }
        }
    }
}
