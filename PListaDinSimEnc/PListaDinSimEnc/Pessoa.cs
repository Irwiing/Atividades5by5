using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PListaDinSimEnc
{
    class Pessoa
    {
        public string Nome { get; set; }
        public Telefone telefone { get; set; }


        public override string ToString()
        {

            return $"\n>>DADOS DO CONTATO<<<\nNome: {Nome}\nTelefone: {telefone}";
        }

        public string ToCsvConverter()
        {
            return $"{Nome},{telefone.DDD},{telefone.Numero},{telefone.Tipo}";
        }
    }
}