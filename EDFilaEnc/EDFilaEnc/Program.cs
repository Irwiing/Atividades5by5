using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDFilaEnc
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueOS myQueue = new QueueOS() 
            {
                Head = null,
                Tail = null
            };
            int op;

            do
            {
                Console.Clear();
                Console.WriteLine("\nx-----------MENU-----------x\n");
                Console.WriteLine("Informe a opção desejada:\n ");
                Console.WriteLine("(1) Inserir Ordem de Serviço.");
                Console.WriteLine("(2) Remover  Ordem de Serviço.");
                Console.WriteLine("(3) Listar  Ordem de Serviço.");
                Console.WriteLine("(4) Ver tamanho da fila.");
                Console.WriteLine("(5) Buscar por Ordem de Serviço.");
                Console.WriteLine("(0) Sair.");
                Console.WriteLine("\nx--------Ordem de Serviço--------x\n");

                Console.Write("Sua opção: ");
                string opTmp = Console.ReadLine();

                if (int.TryParse(opTmp, out op))
                {
                    switch (op)
                    {
                        case 1:
                            ServiceOrder newOS = CreateOS();
                            myQueue.Push(newOS);

                            Console.WriteLine("Aperte qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            Console.Write("\n------------Remoção de Ordem de Serviço------------\n");
                            myQueue.Pop();

                            Console.WriteLine("Aperte qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            Console.Write("\n------------Listar Ordens de Serviços------------\n");
                            myQueue.ShowQueue();

                            Console.WriteLine("Aperte qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Clear();
                            Console.Write("\n------------Contagem de Ordem de Serviço------------\n");
                            Console.WriteLine($"\nVocê tem {myQueue.Length} Ordem(s) de Serviço(s).\n");

                            Console.WriteLine("Aperte qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            Console.Write("\n------------Procurar por Ordem de Serviço------------\n");
                            Console.WriteLine("Informe o numero da ordem que deseja procurar.\n");
                            int number = int.Parse(Console.ReadLine());
                            myQueue.FindOSByNumber(number);

                            Console.WriteLine("Aperte qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (op != 0);
        }
        static ServiceOrder CreateOS()
        {
            Console.Clear();
            Console.Write("\n------------Cadastro de Ordem de Serviçõ------------\n");
            Console.Write("\nInforme o Numero da Ordem de Serviço: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("\nInforme o Tipo da Ordem de Serviço: ");
            string type = Console.ReadLine();
            Console.Write("\nInforme a descrição da Ordem de Serviço: ");
            string description = Console.ReadLine();
            Console.Write("\nInforme o prazo em dias da Ordem de Serviço: ");
            int deadline = int.Parse(Console.ReadLine());

            return new ServiceOrder()
            {
                Number = number,
                Type = type,
                Description = description,
                CreationDate = DateTime.Now,
                Deadline = deadline,
                Next = null,
            };
        }
    }
}
