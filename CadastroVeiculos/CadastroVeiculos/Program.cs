using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroVeiculos
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa[] pessoas = new Pessoa[1];
            int op = 0;
            while (op != 3) 
            {
                Console.Clear();
                Console.WriteLine("\nx-----------MENU-----------x\n");
                Console.WriteLine("Informe a opção desejada:\n ");
                Console.WriteLine("(1) Cadastrar os dados.");
                Console.WriteLine("(2) Listar os dados.");
                Console.WriteLine("(3) Sair.");
                Console.WriteLine("\nx--------------------------x\n");
                Console.Write("Sua opção: ");
                string opTmp = Console.ReadLine();

                if (int.TryParse(opTmp, out op))
                {
                    switch (op)
                    {
                        case 1:
                            Console.Clear();
                            pessoas[0] = CadastrarDados();
                            
                            break;
                        case 2:
                            Console.Clear();
                            if (pessoas[0] != null)
                                pessoas[0].ListarDados();
                            break;
                    }
                }

            }
        }
        static Pessoa CadastrarDados()
        {
            
            Console.WriteLine("Informe os dados do usuario: ");
            Console.Write("\nNome: ");
            string nome = Console.ReadLine();
            Console.Write("\nCpf: ");
            string cpf = Console.ReadLine();
            Console.Write("\nEndereco: ");
            string endereco = Console.ReadLine();
            Console.Write("\nData de nascimento: ");
            string dataNasc = Console.ReadLine();
            Console.Write("\nData de compra do veículo: ");
            string dataCompra = Console.ReadLine();

            
            Console.WriteLine("Informe os dados do veículo: \n");
            Console.Write("\nRenavam: ");
            string veiculoRenavam = Console.ReadLine();
            Console.Write("\nChassi: ");
            string veiculoChassi = Console.ReadLine();
            Console.Write("\nPlaca: ");
            string veiculoPlaca = Console.ReadLine();
            Console.Write("\nMarca: ");
            string veiculoMarca = Console.ReadLine();
            Console.Write("\nModelo: ");
            string veiculoModelo = Console.ReadLine();
            Console.Write("\nCor: ");
            string veiculoCor = Console.ReadLine();
            Console.Write("\nAno: ");
            string veiculoAno = Console.ReadLine();

            
            Pessoa p = new Pessoa()
            {
                Nome = nome,
                Cpf = cpf,
                Endereco = endereco,
                DataNasc = dataNasc,
                DataCompra = dataCompra,
                veiculo = new Veiculo()
                {
                    Renavam = veiculoRenavam,
                    Chassi = veiculoChassi,
                    Placa = veiculoPlaca,
                    Marca = veiculoMarca,
                    Modelo = veiculoModelo,
                    Cor = veiculoCor,
                    Ano = veiculoAno
                }
            };
            return p;
        }
    }
}
