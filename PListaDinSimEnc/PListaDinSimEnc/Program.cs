using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PListaDinSimEnc
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Pessoa> listaContatos = new List<Pessoa>();

            int op = -1;
            while (op != 0)
            {
                op = Menu();

                switch (op)
                {
                    case 1:
                        Pessoa pessoa = FormularioPessoa();
                        FormularioTelefone(pessoa);
                        ListaContatosAdd(pessoa, listaContatos);
                        break;
                    case 2:
                        Pessoa pessoaRemover = FormularioPessoa();
                        ListaContatosRemove(pessoaRemover, listaContatos);
                        break;
                    case 3:
                        Pessoa pessoaProcurar = FormularioPessoa();
                        ListaContatosProcurar(pessoaProcurar, listaContatos);
                        break;
                    case 4:
                        ListaContatosListar(listaContatos);
                        break;
                    case 5:
                        ListaContatosPassar(listaContatos);
                        break;
                    case 6:
                        Console.WriteLine($"Sua lista tem: {listaContatos.Count} contatos.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void VerContato(Pessoa pessoa)
        {
            string op;
            int intOp;
            if (pessoa == null)
            {
                Console.WriteLine("\nNão tem contatos");
            }
            do
            {
                Console.Clear();
                Console.WriteLine(pessoa.ToString());
                if (pessoa.Proximo != null)
                {
                    pessoa = pessoa.Proximo;
                    Console.WriteLine("\n\t1 - Proximo\t0 - Menu");
                    op = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("\nFim da lista");
                    Console.ReadKey();
                    return;
                }
                if (!int.TryParse(op, out intOp))
                {
                    VerContato(pessoa);
                }
            } while (intOp != 0);
        }
        static void ListaContatosAdd(Pessoa pessoa, List<Pessoa> listaContatos)
        {
            listaContatos.Add(pessoa);
            Console.WriteLine("\nContato adicionado com sucesso!");
            Console.ReadKey();
        }
        static void ListaContatosRemove(Pessoa pessoa, List<Pessoa> ListaContatos)
        {
            ListaContatos?.ForEach(contato =>
            {
                if (contato.Nome.Equals(pessoa.Nome))
                {
                    pessoa = contato;
                    return;
                }
            });
            if (ListaContatos.Remove(pessoa))
                Console.WriteLine("\nContato removido com sucesso!");
            else
                Console.WriteLine("\nContato não existe/fila está vazia");

            Console.ReadKey();
        }
        static void ListaContatosListar(List<Pessoa> ListaContatos)
        {
            ListaContatos.Sort((contato1, contato2) => contato1.Nome.CompareTo(contato2.Nome));
            ListaContatos?.ForEach(contato =>
            {
                Console.WriteLine(contato);
            });
            Console.ReadKey();
        }
        static void ListaContatosProcurar(Pessoa pessoa, List<Pessoa> ListaContatos)
        {

            Console.WriteLine(ListaContatos?.Find(contato => contato.Nome.Equals(pessoa.Nome)));
            Console.ReadKey();
        }
        static void ListaContatosPassar(List<Pessoa> ListaContatos)
        {
            ListaContatos?.Sort((contato1, contato2) => contato1.Nome.CompareTo(contato2.Nome));
            ListaContatos.ForEach(contato =>
            {
                Console.WriteLine(contato);

                Console.WriteLine("\n0 - Sair\n1 - Proximo");
                int op = int.Parse(Console.ReadLine());
                if (op == 0)
                    return;
            });
        }
        static Pessoa FormularioPessoa()
        {
            Console.Clear();
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            return new Pessoa
            {
                Nome = nome
            };
        }
        static void FormularioTelefone(Pessoa pessoa)
        {
            string op;
            List<Telefone> telefones = new List<Telefone>();
            do
            {

                Console.Write("DDD: ");
                string ddd = Console.ReadLine();

                Console.Write("Numero: ");
                string numero = Console.ReadLine();

                Console.Write("Tipo de contato: ");
                string tipo = Console.ReadLine();

                if (!int.TryParse(ddd, out int intDDD) || !int.TryParse(numero, out int intNumero))
                {
                    FormularioTelefone(pessoa);
                }
                else
                {
                    telefones.Add(new Telefone
                    {
                        DDD = intDDD,
                        Numero = intNumero,
                        Tipo = tipo,
                    });
                }

                Console.WriteLine("\nGostaria de cadastrar outro numero para este contato?\nSIM\tNAO");
                op = Console.ReadLine();
            } while (op.ToUpper() != "NAO");

            pessoa.telefone = telefones;

        }
        static int Menu()
        {
            int op;
            Console.Clear();
            Console.WriteLine("--------\tMenu\t--------");
            Console.WriteLine("[1]\tInserir Contato\n" +
                "[2]\tRemover Contato\n" +
                "[3]\tLocalizar Contato\n" +
                "[4]\tListar Contatos\n" +
                "[5]\tVisualizar Contato\n" +
                "[6]\tQuantidade de Contatos\n" +
                "[0]\tSair\n");
            string menu = Console.ReadLine();
            if (int.TryParse(menu, out op))
            {
                return op;
            }
            return -1;
        }
    }
}