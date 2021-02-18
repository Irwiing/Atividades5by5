using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdPilhaLivros
{
    class BookStack
    {
        public Book Top { get; set; }

        public void Push(Book aux)
        {
            aux.Previous = Top;
            Top = aux;
            Console.Write("\nLivro adicionado com sucesso!\n");
        }
        private bool isNull()
        {
            if (Top == null)
                return true;
            return false;
        }
        public void Pop()
        {
            if (isNull()) 
            {
                Console.WriteLine("\nNão há livros à ser removido!");
                
            }
            else
            {
                Top = Top.Previous;
                Console.WriteLine("\nLivro removido com sucesso!\n");
            }
        }

        public void ShowStack()
        {
            if (isNull())
            {
                Console.WriteLine("\nNão há livros cadastrados\n");
            }
            else
            {
                Book aux = Top;                
                do
                {
                    Console.WriteLine(aux.ToString());
                    aux = aux.Previous;
                } while (aux != null);
                
            }
        }
        public int CountBooks()
        {
            int cont = 0;

            if (isNull())
            {
                return cont;
            }
            else
            {
                Book aux = Top;
                do
                {
                    aux = aux.Previous;
                    cont++;
                } while (aux != null);

                return cont;
            }
        }
        public void FindBookByTitle(string title)
        {
            bool find = false;
            if (isNull())
            {
                Console.WriteLine("\nNão há livros cadastrados\n");
            }
            else
            {
                Book aux = Top;
                do
                {
                    if(aux.Title.ToUpper().Contains(title.ToUpper()))
                    {
                        Console.WriteLine(aux.ToString());
                        find = true;
                    }
                    aux = aux.Previous;                   

                } while (aux != null);
            }
            if(!find)
                Console.WriteLine("\nNão há livros cadastrados com esse titulo.\n");
        }
    }
}
