using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

Suite suite = null;
Reserva reserva = null;
List<Pessoa> hospedes = new List<Pessoa>();

bool continuar = true;

while (continuar)
{
    Console.Clear();
    Console.WriteLine("==== Menu de Reserva ====");
    Console.WriteLine("1 - Cadastrar suíte");
    Console.WriteLine("2 - Cadastrar hóspedes");
    Console.WriteLine("3 - Exibir quantidade de hóspedes");
    Console.WriteLine("4 - Exibir valor da diária");
    Console.WriteLine("5 - Exibir dados completos da reserva");
    Console.WriteLine("6 - Sair");
    
    Console.Write("Escolha uma opção: ");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Tipo da suíte: ");
            string tipo = Console.ReadLine();

            Console.Write("Capacidade: ");
            int capacidade = int.Parse(Console.ReadLine());

            Console.Write("Valor da diária: ");
            decimal valor = decimal.Parse(Console.ReadLine());

            suite = new Suite(tipo, capacidade, valor);

            Console.Write("Quantidade de dias reservados: ");
            int dias = int.Parse(Console.ReadLine());

            reserva = new Reserva(dias);
            reserva.CadastrarSuite(suite);

            Console.WriteLine("Suíte cadastrada com sucesso!");
            break;

        case "2":
            if (reserva == null)
            {
                Console.WriteLine("Você precisa cadastrar a suíte primeiro!");
                break;
            }

            Console.Write("Quantos hóspedes deseja cadastrar? ");
            int qtd = int.Parse(Console.ReadLine());

            hospedes = new List<Pessoa>();

            for (int i = 0; i < qtd; i++)
            {
                Console.Write($"Nome do hóspede {i + 1}: ");
                string nome = Console.ReadLine();

                Console.Write($"Sobrenome do hóspede {i + 1}: ");
                string sobrenome = Console.ReadLine();

                hospedes.Add(new Pessoa(nome, sobrenome));
            }

            try
            {
                reserva.CadastrarHospedes(hospedes);
                Console.WriteLine("Hóspedes cadastrados com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            break;

        case "3":
            if (reserva == null || reserva.Hospedes == null)
            {
                Console.WriteLine("Nenhuma reserva ou hóspedes encontrados.");
            }
            else
            {
                Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
            }
            break;

        case "4":
            if (reserva == null)
            {
                Console.WriteLine("Nenhuma reserva encontrada.");
            }
            else
            {
                Console.WriteLine($"Valor total da diária: R$ {reserva.CalcularValorDiaria():0.00}");
            }
            break;

        case "5":
            if (reserva == null || reserva.Hospedes == null)
            {
                Console.WriteLine("Nenhuma reserva encontrada.");
            }
            else
            {
                Console.WriteLine("\n=== Detalhes da Reserva ===");
                Console.WriteLine($"Tipo da Suíte: {reserva.Suite.TipoSuite}");
                Console.WriteLine($"Capacidade da Suíte: {reserva.Suite.Capacidade}");
                Console.WriteLine($"Valor da Diária: R$ {reserva.Suite.ValorDiaria:0.00}");
                Console.WriteLine($"Dias Reservados: {reserva.DiasReservados}");
                Console.WriteLine($"Valor Total: R$ {reserva.CalcularValorDiaria():0.00}");
                Console.WriteLine($"Quantidade de Hóspedes: {reserva.ObterQuantidadeHospedes()}");

                Console.WriteLine("\n--- Lista de Hóspedes ---");
                foreach (var h in reserva.Hospedes)
                {
                    Console.WriteLine($"- {h.NomeCompleto}");
                }
            }
            break;
        case "6":
            continuar = false;
            Console.WriteLine("Saindo...");
            break;        

        default:
            Console.WriteLine("Opção inválida!");
            break;
    }

    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}
