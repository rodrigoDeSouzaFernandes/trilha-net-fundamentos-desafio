using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        static bool PlacaValida(string placa)
        {
            string padrao = @"^[A-Z]{3}-\d{4}$";
            return Regex.IsMatch(placa, padrao);
        }

        public void AdicionarVeiculo()
        {
            Console.Clear();
            string placaDoVeiculo;
            do
            {
                Console.WriteLine(
                    "Digite a placa do veículo no formato \"ABC-1234\" para estacionar:\n"
                );
                placaDoVeiculo = Console.ReadLine();
            } while (!PlacaValida(placaDoVeiculo));

            veiculos.Add(placaDoVeiculo);
        }

        public void RemoverVeiculo()
        {
            Console.Clear();

            Console.WriteLine("Digite a placa do veículo para remover: (ABC-1234)\n");

            string placa = Console.ReadLine();

            while (!PlacaValida(placa))
            {
                Console.WriteLine("Digite uma placa válida: (ABC-1234)\n");
                placa = Console.ReadLine();
            }

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horas = 0;
                horas = LeitorHelper.LerHoraValida(
                    "Digite a quantidade de horas que o veículo permaneceu estacionado:\n"
                );

                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa);

                Console.WriteLine(
                    $"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}\n"
                );
            }
            else
            {
                Console.WriteLine(
                    "Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente\n"
                );
            }
        }

        public void ListarVeiculos()
        {
            Console.Clear();

            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:\n");
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.\n");
            }
        }
    }
}
