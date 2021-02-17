using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdPilhaLivros
{
    class Program
    {
        static void Main(string[] args)
        {
            BookStack myStack = new BookStack() { Top = null };
            int op;

            do
            {
                Console.Clear();
                Console.WriteLine("\nx-----------MENU-----------x\n");
                Console.WriteLine("Informe a opção desejada:\n ");
                Console.WriteLine("(1) Inserir Livro.");
                Console.WriteLine("(2) Remover Livro.");
                Console.WriteLine("(3) Consultar Estante.");
                Console.WriteLine("(4) Consultar numeros de livros.");
                Console.WriteLine("(5) Buscar por livro.");
                Console.WriteLine("(0) Sair.");
                Console.WriteLine("\nx--------Biblioteca--------x\n");
               
                Console.Write("Sua opção: ");
                string opTmp = Console.ReadLine();

                if (int.TryParse(opTmp, out op))
                {
                    switch (op)
                    {
                        case 1:
                            Book newBook = CreateBook();
                            myStack.Push(newBook);

                            Console.WriteLine("Aperte qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            Console.Write("\n------------Remoção de livros------------\n");
                            myStack.Pop();

                            Console.WriteLine("Aperte qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            Console.Write("\n------------Estante de livros------------\n");
                            myStack.ShowStack();

                            Console.WriteLine("Aperte qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Clear();
                            Console.Write("\n------------Contagem de livros------------\n");
                            Console.WriteLine($"\nA estante tem {myStack.CountBooks()} livro(s).\n");

                            Console.WriteLine("Aperte qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            Console.Write("\n------------Contagem de livros------------\n");
                            Console.WriteLine("Informe o titulo que deseja procurar.\n");
                            string title = Console.ReadLine();
                            myStack.FindBookByTitle(title);

                            Console.WriteLine("Aperte qualquer tecla para continuar");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (op != 0);
        }
        static Book CreateBook()
        {
            Console.Clear();
            Console.Write("\n------------Cadastro de livros------------\n");
            Console.Write("\nInforme o Titulo do livro: ");
            string title = Console.ReadLine();
            Console.Write("\nInforme o Autor do livro: ");
            string author = Console.ReadLine();
            Console.Write("\nInforme o Isbn do livro: ");
            int isbn = int.Parse(Console.ReadLine());

            return new Book() 
            {
                Title = title,
                Author = author,
                Isbn = isbn
            };
        }
    }
}
