using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente
{
    class User
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Cpf { get; set; }
        public CurrentAccount currentAccount { get; set; }
    }
}
