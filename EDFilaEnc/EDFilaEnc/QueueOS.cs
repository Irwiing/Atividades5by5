using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDFilaEnc
{
    class QueueOS
    {
        public ServiceOrder Head { get; set; }
        public ServiceOrder Tail { get; set; }
        public int Length { get; set; }

        public bool IsEmpty()
        {
            if ((Head == null) && (Tail == null))
                return true;
            return false;
        }

        public void Push(ServiceOrder aux)
        {
            if (IsEmpty())
            {
                Head = aux;
                Tail = aux;
            }
            else
            {
                Tail.Next = aux;
                Tail = aux;
            }
            Length++;
            Console.WriteLine("Elemento Inserido com sucesso!!!");
        }

        public void ShowQueue()
        {
            if(IsEmpty())
            {
                Console.WriteLine("Impossível Imprimir! Fila Vazia!");
            }
            else
            {
                ServiceOrder aux = Head;
                Console.WriteLine("\n>>>AS Ordens de Serviço são<<<\n");
                do
                {
                    Console.WriteLine(aux.ToString());
                    aux = aux.Next;
                } while (aux != null);
                Console.WriteLine("\n>>> FIM DA IMPRESSÃO <<<");
            }
        }
        public void Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Impossível Remover! Fila Vazia!");                
            }
            else
            {
                Head = Head.Next;
                Length--;
                Console.WriteLine("Elemento Removido com Sucesso!");
                if (Head == null)
                {
                    Tail = null;
                    Console.WriteLine("Fila agora está vazia!");
                    
                }
            }
        }
        public void FindOSByNumber(int number)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Impossível Imprimir! Fila Vazia!");
                return;
            }
            else
            {
                ServiceOrder aux = Head;
                Console.WriteLine("\n>>>AS Ordens de Serviço são<<<\n");
                do
                {
                    if (aux.Number == number)
                    {
                        Console.WriteLine(aux.ToString());
                        return;
                    }
                    
                    aux = aux.Next;
                } while (aux != null);
                Console.WriteLine("\n>>> FIM DA IMPRESSÃO <<<");
            }
            Console.WriteLine("\nNão há Ordem de Serviço cadastrados com esse numero.\n");
        }
    }
}
