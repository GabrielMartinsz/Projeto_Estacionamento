using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            Console.WriteLine("Digite a marca do veículo:");
            string marca = Console.ReadLine();

            Veiculo veiculo = new Veiculo(placa, marca);
            veiculos.Add(veiculo);

            Console.WriteLine($"Veículo com placa {placa} e marca {marca} adicionado ao estacionamento.");
        }

        public class Veiculo
    {
        public string Placa { get; set; }
        public string Marca { get; set; }

        public Veiculo(string placa, string marca)
        {
            Placa = placa;
            Marca = marca;
        }
    }

        public void RemoverVeiculo()
{
    Console.WriteLine("Digite a placa do veículo para remover:");
    string placa = Console.ReadLine();

    if (veiculos.Any(x => x.Placa.ToUpper() == placa.ToUpper()))
    {
        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
        int horas = Convert.ToInt32(Console.ReadLine());
        
        decimal valorTotal = (horas <= 1) ? precoInicial : precoInicial + (precoPorHora * (horas - 1));

        Veiculo veiculoRemover = veiculos.First(x => x.Placa.ToUpper() == placa.ToUpper());
        veiculos.Remove(veiculoRemover);

        Console.WriteLine($"O veículo {veiculoRemover.Placa} (marca: {veiculoRemover.Marca}) foi removido e o preço total foi de: R$ {valorTotal}");
    }
    else
    {
        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
    }
}

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Placa: {veiculo.Placa}, Marca: {veiculo.Marca}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
 
    }

}
