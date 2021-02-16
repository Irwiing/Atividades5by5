using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroVeiculos
{
    class Pessoa
    {
        //CPF, NOME, ENDEREÇO, DATA NASCIMENTO, DATA_COMPRA
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set;}
        public string DataNasc { get; set; }
        public Veiculo veiculo { get; set; }
        public string DataCompra { get; set; }
        public void ListarDados()
        {
            
            Console.WriteLine("Informações do usuario: ");
            Console.Write($"\nNome: {Nome}");
            Console.Write($"\nCpf: {Cpf}");
            Console.Write($"\nEndereco: {Endereco}");
            Console.Write($"\nData de nascimento: {DataNasc}");
            Console.Write($"\nData de compra do veículo: {DataCompra}");

            Console.WriteLine("\nInformações do Veiculo: ");
            Console.Write($"\nRenavam: {veiculo.Renavam}");
            Console.Write($"\nChassi: {veiculo.Chassi}");
            Console.Write($"\nPlaca: {veiculo.Placa}");
            Console.Write($"\nMarca: {veiculo.Marca}");
            Console.Write($"\nModelo: {veiculo.Modelo}");
            Console.Write($"\nCor: {veiculo.Cor}");
            Console.Write($"\nAno: {veiculo.Ano}");

            Console.WriteLine("\nAperte Qualquer tecla para voltar para o menu!");
            Console.ReadKey();
        }

    }
}
