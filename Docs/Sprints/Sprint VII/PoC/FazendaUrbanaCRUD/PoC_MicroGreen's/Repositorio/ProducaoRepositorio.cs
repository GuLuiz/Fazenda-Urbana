using FazendaUrbanaDLL;
using FazendaUrbanaDLL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoC_MicroGreen_s.Repositorio;
public class ProducaoRepositorio
{
    public void InserirProducao()
    {
        string connectionString = "Data Source=localhost;Initial Catalog=MicroGreenDB;Integrated Security=True;";
        ControleFazendaUrbana controleFazenda = new ControleFazendaUrbana(connectionString);
        Console.WriteLine("=== Inserir Produção ===");

        Console.Write("Quantidade: ");
        int quantidade;
        while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade < 0)
        {
            Console.WriteLine("Por favor, insira um valor válido para a quantidade.");
            Console.Write("Quantidade: ");
        }

        Console.Write("Tempo de Cultivo (em dias): ");
        int tempoCultivo;
        while (!int.TryParse(Console.ReadLine(), out tempoCultivo) || tempoCultivo < 0)
        {
            Console.WriteLine("Por favor, insira um valor válido para o tempo de cultivo.");
            Console.Write("Tempo de Cultivo (em dias): ");
        }

        Console.Write("Ativo (true/false): ");
        bool ativo;
        while (!bool.TryParse(Console.ReadLine(), out ativo))
        {
            Console.WriteLine("Por favor, insira 'true' ou 'false'.");
            Console.Write("Ativo (true/false): ");
        }

        Console.Write("Dias Restantes: ");
        int diasRestantes;
        while (!int.TryParse(Console.ReadLine(), out diasRestantes) || diasRestantes < 0)
        {
            Console.WriteLine("Por favor, insira um valor válido para os dias restantes.");
            Console.Write("Dias Restantes: ");
        }

        Console.Write("ID da Matéria-Prima: ");
        int materiaPrimaId;
        while (!int.TryParse(Console.ReadLine(), out materiaPrimaId))
        {
            Console.WriteLine("Por favor, insira um número válido para o ID da matéria-prima.");
            Console.Write("ID da Matéria-Prima: ");
        }

        Console.Write("ID do Funcionário: ");
        int funcionarioId;
        while (!int.TryParse(Console.ReadLine(), out funcionarioId))
        {
            Console.WriteLine("Por favor, insira um número válido para o ID do funcionário.");
            Console.Write("ID do Funcionário: ");
        }

        try
        {
            controleFazenda.InserirProducao(quantidade, tempoCultivo, ativo, diasRestantes, materiaPrimaId, funcionarioId);
            Console.WriteLine("Produção inserida com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao inserir a produção: " + ex.Message);
        }
    }

    public void ListarProducoes()
    {
        string connectionString = "Data Source=localhost;Initial Catalog=MicroGreenDB;Integrated Security=True;";
        ControleFazendaUrbana controleFazenda = new ControleFazendaUrbana(connectionString);
        Console.WriteLine("=== Listar Produções ===");
        try
        {
            List<Producao> producoes = controleFazenda.SelecionarTodasProducoes();
            foreach (Producao producao in producoes)
            {
                Console.WriteLine($"ID: {producao.ProducaoId}");
                Console.WriteLine($"Quantidade: {producao.Quantidade}");
                Console.WriteLine($"Tempo de Cultivo: {producao.TempoCultivacao}");
                Console.WriteLine($"Ativo: {producao.Ativo}");
                Console.WriteLine($"Dias Restantes: {producao.DiasRestantes}");
                Console.WriteLine($"Matéria-Prima ID: {producao.MateriaPrimaId}");
                Console.WriteLine($"Funcionário ID: {producao.FuncionarioId}");
                Console.WriteLine(new string('-', 40)); // Linha separadora
                Console.ReadLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao listar as produções: " + ex.Message);
        }
    }

    public void AtualizarProducao()
    {
        string connectionString = "Data Source=localhost;Initial Catalog=MicroGreenDB;Integrated Security=True;";
        ControleFazendaUrbana controleFazenda = new ControleFazendaUrbana(connectionString);
        Console.WriteLine("=== Atualizar Produção ===");

        Console.Write("ID da Produção: ");
        int producaoId;
        while (!int.TryParse(Console.ReadLine(), out producaoId))
        {
            Console.WriteLine("Por favor, insira um número válido para o ID da produção.");
            Console.Write("ID da Produção: ");
        }

        Console.Write("Nova Quantidade: ");
        int novaQuantidade;
        while (!int.TryParse(Console.ReadLine(), out novaQuantidade) || novaQuantidade < 0)
        {
            Console.WriteLine("Por favor, insira um valor válido para a nova quantidade.");
            Console.Write("Nova Quantidade: ");
        }

        Console.Write("Novo Tempo de Cultivo (em dias): ");
        int novoTempoCultivo;
        while (!int.TryParse(Console.ReadLine(), out novoTempoCultivo) || novoTempoCultivo < 0)
        {
            Console.WriteLine("Por favor, insira um valor válido para o novo tempo de cultivo.");
            Console.Write("Novo Tempo de Cultivo (em dias): ");
        }

        Console.Write("Novo Ativo (true/false): ");
        bool novoAtivo;
        while (!bool.TryParse(Console.ReadLine(), out novoAtivo))
        {
            Console.WriteLine("Por favor, insira 'true' ou 'false'.");
            Console.Write("Novo Ativo (true/false): ");
        }

        Console.Write("Novos Dias Restantes: ");
        int novosDiasRestantes;
        while (!int.TryParse(Console.ReadLine(), out novosDiasRestantes) || novosDiasRestantes < 0)
        {
            Console.WriteLine("Por favor, insira um valor válido para os novos dias restantes.");
            Console.Write("Novos Dias Restantes: ");
        }

        Console.Write("Novo ID da Matéria-Prima: ");
        int novoMateriaPrimaId;
        while (!int.TryParse(Console.ReadLine(), out novoMateriaPrimaId))
        {
            Console.WriteLine("Por favor, insira um número válido para o novo ID da matéria-prima.");
            Console.Write("Novo ID da Matéria-Prima: ");
        }

        Console.Write("Novo ID do Funcionário: ");
        int novoFuncionarioId;
        while (!int.TryParse(Console.ReadLine(), out novoFuncionarioId))
        {
            Console.WriteLine("Por favor, insira um número válido para o novo ID do funcionário.");
            Console.Write("Novo ID do Funcionário: ");
        }

        try
        {
            controleFazenda.AtualizarProducao(producaoId, novaQuantidade, novoTempoCultivo, novoAtivo, novosDiasRestantes, novoMateriaPrimaId, novoFuncionarioId);
            Console.WriteLine("Produção atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao atualizar a produção: " + ex.Message);
        }
    }

    public void DeletarProducao()
    {
        string connectionString = "Data Source=localhost;Initial Catalog=MicroGreenDB;Integrated Security=True;";
        ControleFazendaUrbana controleFazenda = new ControleFazendaUrbana(connectionString);
        Console.WriteLine("=== Deletar Produção ===");
        Console.Write("ID da Produção: ");
        int producaoId;
        while (!int.TryParse(Console.ReadLine(), out producaoId))
        {
            Console.WriteLine("Por favor, insira um número válido para o ID da produção.");
            Console.Write("ID da Produção: ");
        }

        try
        {
            controleFazenda.ExcluirProducao(producaoId);
            Console.WriteLine("Produção excluída com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao excluir a produção: " + ex.Message);
        }
    }
}
