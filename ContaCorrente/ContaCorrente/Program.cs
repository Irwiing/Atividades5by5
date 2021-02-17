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
            User[] users = new User[3];

            int op = -1, id = 0, i, j;
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
                            users[id] = CreateAccount();
                            Console.WriteLine($"Seu ID de acesso a conta é: {id}");
                            id++;
                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal. ");
                            Console.ReadKey();

                            break;
                        case 2:
                            Console.WriteLine("Informe o ID da conta que você deseja depositar");
                            i = int.Parse(Console.ReadLine());
                            Deposit(users[i]);

                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal. ");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine("Informe o ID da conta que você deseja sacar");
                            i = int.Parse(Console.ReadLine());
                            Withdraw(users[i]);

                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal. ");
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.WriteLine("Informe o ID da sua conta");
                            i = int.Parse(Console.ReadLine());
                            Console.WriteLine("Informe o ID da conta que você deseja transferir");
                            j = int.Parse(Console.ReadLine());

                            Transfer(users[i], users[j]);

                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal. ");
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.WriteLine("Informe o ID da conta que você deseja verificar");
                            i = int.Parse(Console.ReadLine());
                            ShowBalance(users[i]);

                            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal. ");
                            Console.ReadKey();
                            break;

                    }
                }
            }
        }
        static User CreateAccount()
        {
            Console.Write("\nInforme seu nome: ");
            string name = Console.ReadLine();
            Console.Write("\nInforme seu cpf: ");
            string cpf = Console.ReadLine();
            Console.Write("\nInforme seu endereço: ");
            string address = Console.ReadLine();


            Console.Write("\nInforme o numero da agencia desejada: ");
            int agency = int.Parse(Console.ReadLine());
            Console.Write("\nInforme seu saldo inicial: ");
            long balance = long.Parse(Console.ReadLine());

            Console.WriteLine("Gerando o numero da conta...");

            Random accountInitial = new Random();
            Random accountFinal = new Random();
            String accountNumber = accountInitial.Next(1000, 9999).ToString();
            accountNumber += accountFinal.Next(10000, 99999).ToString();

            Console.WriteLine($"O seu numero de conta corrente é: {accountNumber}");

            return new User()
            {
                Name = name,
                Cpf = cpf,
                Address = address,
                currentAccount = new CurrentAccount()
                {
                    Agency = agency,
                    Balance = balance,
                    AccountNumber = long.Parse(accountNumber)
                }
            };
        }
        static void Deposit(User user)
        {
            Console.WriteLine($"Fazer deposito na conta: {user.currentAccount.AccountNumber}\nagencia: {user.currentAccount.Agency}");
            Console.WriteLine("Informe quanto você quer depositar: ");
            user.currentAccount.Balance += long.Parse(Console.ReadLine());
            Console.WriteLine("Deposito efeituado com sucesso!");

        }

        static void Withdraw(User user)
        {
            Console.WriteLine($"Fazer saque na conta: {user.currentAccount.AccountNumber}\nagencia: {user.currentAccount.Agency}");
            Console.WriteLine("Informe quanto você quer sacar: ");
            long value = long.Parse(Console.ReadLine());
            if (value > user.currentAccount.Balance)
            {
                Console.WriteLine("Saque negado. Sem saldo!");
                return;
            }
            Console.WriteLine("Saque efeituado com sucesso!");
        }

        static void ShowBalance(User user)
        {
            Console.WriteLine($"\nconta: {user.currentAccount.AccountNumber}\nagencia: {user.currentAccount.Agency}");
            Console.WriteLine($"\nSaldo: {user.currentAccount.Balance}");
        }
        static void Transfer(User from, User to)
        {
            Console.WriteLine($"Fazer transferencia da conta: {from.currentAccount.AccountNumber}\nagencia: {from.currentAccount.Agency}");
            Console.WriteLine("Informe quanto você quer transferir: ");
            long value = long.Parse(Console.ReadLine());
            if (value > from.currentAccount.Balance)
            {
                Console.WriteLine("Saque negado. Sem saldo!");
                return;
            }
            from.currentAccount.Balance -= value;
            to.currentAccount.Balance += value;
            Console.WriteLine("Saque efeituado com sucesso!");
        }
    }
}
