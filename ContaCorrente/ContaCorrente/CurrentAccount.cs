using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente
{
    class CurrentAccount
    {

        public int Agency { get; set; }
        public long AccountNumber { get; set; }
        public long Balance { get; set; }


        public void CreateAccount(User user)
        {
           

            Random accountInitial = new Random();
            Random accountFinal = new Random();
            String accountNumber = accountInitial.Next(1000, 9999).ToString();
            accountNumber += accountFinal.Next(10000, 99999).ToString();


            user.currentAccount.AccountNumber = long.Parse(accountNumber);

            Console.WriteLine($"O seu numero de conta corrente é: {user.currentAccount.AccountNumber}");
            

        }
    }

}
