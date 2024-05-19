using FazendaUrbanaDLL;
using FazendaUrbanaDLL.Entidades;
using PoC_MicroGreen_s.Repositorio;

namespace PoC_MicroGreen_s
{
    internal class Program
    {
        internal static void Main(string[] args)
        {

            int Menu = Menu_Principal();

            do
            {
                switch (Menu)
                {
                    case 1: Menu_Fornecedor(); break;
                    case 2: Menu_MateriaP(); break;
                    case 3: Menu_Producao(); break;
                    case 4: VisualizarDetalhesPedido(); break;

                }
                Menu = Menu_Principal();
            } while (Menu != 5);
        }

        static int Menu_Principal()
        {

            Console.WriteLine($"Escolha uma opção:\n" +
                "1. Fornecedores\n" +
                "2. Matéria-Prima\n" +
                "3. Produção\n" +
                "4. Detalhes de um Pedido\n" +
                "5. Sair\n");

            int Opcao = int.Parse(Console.ReadLine());
            return Opcao;
        }

        static void Menu_Fornecedor()
        {
            FornecedorRepositorio Fornecedor = new FornecedorRepositorio();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("== Menu Fornecedor ==");
                Console.WriteLine("1. Inserir Fornecedor");
                Console.WriteLine("2. Mostrar Fornecedores");
                Console.WriteLine("3. Atualizar Fornecedor");
                Console.WriteLine("4. Deletar Fornecedor");
                Console.WriteLine("5. Voltar ao Menu Principal");
                Console.WriteLine("======================");
                Console.Write("Escolha uma opção: ");
                int Opcao = int.Parse(Console.ReadLine()); ;
                switch (Opcao)
                {
                    case 1:
                        Fornecedor.InserirFornecedor();
                        break;
                    case 2:
                        Fornecedor.MostrarFornecedores();
                        break;
                    case 3:
                        Fornecedor.AtualizarFornecedor();
                        break;
                    case 4:
                        Fornecedor.DeletarFornecedor();
                        break;
                    case 5: return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void Menu_MateriaP()
        {
            MateriaPrimaRepositorio materiaPrima = new MateriaPrimaRepositorio();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Menu Matéria-Prima ===");
                Console.WriteLine("1. Inserir Matéria-Prima");
                Console.WriteLine("2. Listar Matérias-Primas");
                Console.WriteLine("3. Atualizar Matéria-Prima");
                Console.WriteLine("4. Deletar Matéria-Prima");
                Console.WriteLine("5. Voltar ao Menu Principal");
                Console.WriteLine("==========================");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        materiaPrima.InserirMateriaPrima();
                        break;
                    case "2":
                        materiaPrima.ListarMateriasPrimas();
                        break;
                    case "3":
                        materiaPrima.AtualizarMateriaPrima();
                        break;
                    case "4":
                        materiaPrima.DeletarMateriaPrima();
                        break;
                    case "5": return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void Menu_Producao()
        {
            ProducaoRepositorio producao = new ProducaoRepositorio();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Menu Produção ===");
                Console.WriteLine("1. Inserir Produção");
                Console.WriteLine("2. Listar Produções");
                Console.WriteLine("3. Atualizar Produção");
                Console.WriteLine("4. Deletar Produção");
                Console.WriteLine("5. Voltar ao Menu Principal");
                Console.WriteLine("=====================");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        producao.InserirProducao();
                        break;
                    case "2":
                        producao.ListarProducoes();
                        break;
                    case "3":
                        producao.AtualizarProducao();
                        break;
                    case "4":
                        producao.DeletarProducao();
                        break;
                    case "5": return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void VisualizarDetalhesPedido()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=MicroGreenDB;Integrated Security=True;";
            ControleFazendaUrbana controleFazenda = new ControleFazendaUrbana(connectionString);

            Console.WriteLine("=== Visualizar Detalhes do Pedido ===");

            bool continuarVisualizando = true;

            do
            {
                Console.Write("ID do Pedido: ");
                int idPedido;
                while (!int.TryParse(Console.ReadLine(), out idPedido))
                {
                    Console.WriteLine("Por favor, insira um número válido para o ID do pedido.");
                    Console.Write("ID do Pedido: ");
                }

                // Aqui você pode chamar o método para obter e exibir os detalhes do pedido
                controleFazenda.GetPedidoDetalhes(idPedido);

                Console.WriteLine("Deseja visualizar detalhes de outro pedido? (s/n)");
                string resposta = Console.ReadLine().ToLower();

                continuarVisualizando = resposta == "s";

            } while (continuarVisualizando);

        }

    }
}
