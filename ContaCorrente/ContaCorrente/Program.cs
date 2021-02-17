using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] users = new User[1];

            int op = -1;
            while (op != 0)
            {
                Console.Clear();
                Console.WriteLine("\nx-----------MENU-----------x\n");
                Console.WriteLine("Informe a opção desejada:\n ");
                Console.WriteLine("(1) Abrir uma conta corrente.");
                Console.WriteLine("(2) Fazer deposito.");
                Console.WriteLine("(3) Fazer saque.");
                Console.WriteLine("(4) Fazer Transferencia.");
                Console.WriteLine("(5) Consultar saldo.");
                Console.WriteLine("(0) Sair.");
                Console.WriteLine("\nx----Banco do Brasirwing----\n");
                Console.Write("Sua opção: ");
                string opTmp = Console.ReadLine();

                if (int.TryParse(opTmp, out op))
                {
                    switch (op)
                    {
                        case 1:
                            Console.Clear();
                            users[0] = new User();
                            Console.Write("\nInforme seu nome: ");
                            users[0].Name = Console.ReadLine();
                            Console.Write("\nInforme seu cpf: ");
                            users[0].Cpf = Console.ReadLine();
                            Console.Write("\nInforme seu endereço: ");
                            users[0].Address = Console.ReadLine();

                            users[0].currentAccount = new CurrentAccount();
                            Console.Write("\nInforme o numero da agencia desejada: ");
                            users[0].currentAccount.Agency = int.Parse(Console.ReadLine());
                            Console.Write("\nInforme seu saldo inicial: ");
                            users[0].currentAccount.Balance = long.Parse(Console.ReadLine());

                            Console.WriteLine("Gerando o numero da conta...");
                            users[0].currentAccount.CreateAccount(users[0]);

                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal. ");
                            Console.ReadKey();

                            break;
                        case 2:
                            Console.WriteLine($"Fazer deposito na conta: {users[0].currentAccount.AccountNumber}\nagencia: {users[0].currentAccount.Agency}");
                            Console.WriteLine("Informe quanto você quer depositar: ");
                            users[0].currentAccount.Balance += long.Parse(Console.ReadLine());
                            Console.WriteLine("Deposito efeituado com sucesso!");
                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal. ");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine($"Fazer saque na conta: {users[0].currentAccount.AccountNumber}\nagencia: {users[0].currentAccount.Agency}");
                            Console.WriteLine("Informe quanto você quer sacar: ");
                            users[0].currentAccount.Balance -= long.Parse(Console.ReadLine());
                            Console.WriteLine("Saque efeituado com sucesso!");
                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal. ");
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.WriteLine($"Fazer transferencia da conta: {users[0].currentAccount.AccountNumber}\nagencia: {users[0].currentAccount.Agency}");
                            Console.WriteLine("Informe quanto você quer transferir: ");
                            users[0].currentAccount.Balance -= long.Parse(Console.ReadLine());
                            Console.WriteLine("transferencia efeituado com sucesso!");
                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal. ");
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.WriteLine($"\nconta: {users[0].currentAccount.AccountNumber}\nagencia: {users[0].currentAccount.Agency}");
                            Console.WriteLine($"\nSaldo: {users[0].currentAccount.Balance}");
                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal. ");
                            Console.ReadKey();
                            break;

                    }
                }
            }
        }
    }
}
