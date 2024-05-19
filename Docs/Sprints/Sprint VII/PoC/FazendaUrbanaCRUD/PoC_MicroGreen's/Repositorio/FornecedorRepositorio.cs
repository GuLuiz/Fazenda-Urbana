using FazendaUrbanaDLL;
using FazendaUrbanaDLL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoC_MicroGreen_s.Repositorio;
public class FornecedorRepositorio
{
    public void InserirFornecedor()
    {
        string connectionString = "Data Source=localhost;Initial Catalog=MicroGreenDB;Integrated Security=True;";
        ControleFazendaUrbana controleFazenda = new ControleFazendaUrbana(connectionString);

        Console.WriteLine("=== Inserir Fornecedor ===");

        Console.Write("CNPJ: ");
        string cnpj = Console.ReadLine();

        Console.Write("Razão Social: ");
        string razaoSocial = Console.ReadLine();

        Console.Write("Ativo (true/false): ");
        bool ativo;
        while (!bool.TryParse(Console.ReadLine(), out ativo))
        {
            Console.WriteLine("Por favor, insira 'true' ou 'false'.");
            Console.Write("Ativo (true/false): ");
        }

        Console.Write("Cidade: ");
        string cidade = Console.ReadLine();

        Console.Write("Estado: ");
        string estado = Console.ReadLine();

        Console.Write("País: ");
        string pais = Console.ReadLine();

        Console.Write("Inscrição Estadual: ");
        string inscricaoEstadual = Console.ReadLine();

        Console.Write("Contato Principal: ");
        string contatosPrincipal = Console.ReadLine();

        try
        {
            controleFazenda.InserirFornecedor(cnpj, razaoSocial, ativo, cidade, estado, pais, inscricaoEstadual, contatosPrincipal);
            Console.WriteLine("Fornecedor inserido com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao inserir o fornecedor: " + ex.Message);
        }
    }
    public void MostrarFornecedores()
    {
        try
        {
            string connectionString = "Data Source=localhost;Initial Catalog=MicroGreenDB;Integrated Security=True;";

            ControleFazendaUrbana controleFazenda = new ControleFazendaUrbana(connectionString);
            List<Fornecedor> fornecedores = controleFazenda.SelecionarTodosFornecedores();

            foreach (Fornecedor fornecedor in fornecedores)
            {
                Console.WriteLine("ID: " + fornecedor.FornecedorId);
                Console.WriteLine("CNPJ: " + fornecedor.Cnpj);
                Console.WriteLine("Razão Social: " + fornecedor.RazaoSocial);
                Console.WriteLine("Ativo: " + fornecedor.Ativo);
                Console.WriteLine("Cidade: " + fornecedor.Cidade);
                Console.WriteLine("Estado: " + fornecedor.Estado);
                Console.WriteLine("País: " + fornecedor.Pais);
                Console.WriteLine("Inscrição Estadual: " + fornecedor.InscricaoEstadual);
                Console.WriteLine("Contato Principal: " + fornecedor.ContatosPrincipal);
                Console.WriteLine(new string('-', 40)); // Linha separadora
                Console.ReadLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao mostrar os fornecedores: " + ex.Message);
        }
    }

    public void AtualizarFornecedor()
    {
        string connectionString = "Data Source=localhost;Initial Catalog=MicroGreenDB;Integrated Security=True;";
        ControleFazendaUrbana controleFazenda = new ControleFazendaUrbana(connectionString);

        Console.WriteLine("=== Atualizar Fornecedor ===");

        Console.Write("ID do Fornecedor: ");
        int fornecedorId;
        while (!int.TryParse(Console.ReadLine(), out fornecedorId))
        {
            Console.WriteLine("Por favor, insira um número válido para o ID do fornecedor.");
            Console.Write("ID do Fornecedor: ");
        }

        Console.Write("Novo CNPJ: ");
        string novoCnpj = Console.ReadLine();

        Console.Write("Nova Razão Social: ");
        string novaRazaoSocial = Console.ReadLine();

        Console.Write("Novo Ativo (true/false): ");
        bool novoAtivo;
        while (!bool.TryParse(Console.ReadLine(), out novoAtivo))
        {
            Console.WriteLine("Por favor, insira 'true' ou 'false'.");
            Console.Write("Novo Ativo (true/false): ");
        }

        Console.Write("Nova Cidade: ");
        string novaCidade = Console.ReadLine();

        Console.Write("Novo Estado: ");
        string novoEstado = Console.ReadLine();

        Console.Write("Novo País: ");
        string novoPais = Console.ReadLine();

        Console.Write("Nova Inscrição Estadual: ");
        string novaInscricaoEstadual = Console.ReadLine();

        Console.Write("Novo Contato Principal: ");
        string novosContatosPrincipal = Console.ReadLine();

        try
        {
            controleFazenda.AtualizarFornecedor(fornecedorId, novoCnpj, novaRazaoSocial, novoAtivo, novaCidade, novoEstado, novoPais, novaInscricaoEstadual, novosContatosPrincipal);
            Console.WriteLine("Fornecedor atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao atualizar o fornecedor: " + ex.Message);
        }
    }


    public void DeletarFornecedor()
    {
        string connectionString = "Data Source=localhost;Initial Catalog=MicroGreenDB;Integrated Security=True;";
        ControleFazendaUrbana controleFazenda = new ControleFazendaUrbana(connectionString);

        Console.WriteLine("=== Deletar Fornecedor ===");
        Console.Write("ID do Fornecedor: ");
        int fornecedorId;
        while (!int.TryParse(Console.ReadLine(), out fornecedorId))
        {
            Console.WriteLine("Por favor, insira um número válido para o ID do fornecedor.");
            Console.Write("ID do Fornecedor: ");
        }

        try
        {
            controleFazenda.ExcluirFornecedor(fornecedorId);
            Console.WriteLine("Fornecedor excluído com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao excluir o fornecedor: " + ex.Message);
        }
    }
}
