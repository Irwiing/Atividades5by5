using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDFilaEnc
{
    class ServiceOrder
    {
        public int Number { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int Deadline { get; set; }
        public ServiceOrder Next { get; set; }

        public override string ToString()
        {
            return "\n>>>DADOS DA O.S.<<<\nNumero da O.S.:" + Number + "\nTipo:" + Type + "\nDescrição:" + Description + "\nData da Pedido:" + CreationDate + "\nPraza em dias:" + Deadline; ;
        }
    }
}
    