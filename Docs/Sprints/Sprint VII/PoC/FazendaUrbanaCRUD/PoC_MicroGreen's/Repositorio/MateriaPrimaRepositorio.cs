using FazendaUrbanaDLL;
using FazendaUrbanaDLL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoC_MicroGreen_s.Repositorio;
public class MateriaPrimaRepositorio
{
    public void InserirMateriaPrima()
    {
        string connectionString = "Data Source=localhost;Initial Catalog=MicroGreenDB;Integrated Security=True;";
        ControleFazendaUrbana controleFazenda = new ControleFazendaUrbana(connectionString);
        Console.WriteLine("=== Inserir Matéria-Prima ===");

        Console.Write("Tipo: ");
        string tipo = Console.ReadLine();

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Ativo (true/false): ");
        bool ativo;
        while (!bool.TryParse(Console.ReadLine(), out ativo))
        {
            Console.WriteLine("Por favor, insira 'true' ou 'false'.");
            Console.Write("Ativo (true/false): ");
        }

        Console.Write("ID da Imagem: ");
        int imagemId;
        while (!int.TryParse(Console.ReadLine(), out imagemId))
        {
            Console.WriteLine("Por favor, insira um número válido para o ID da imagem.");
            Console.Write("ID da Imagem: ");
        }

        Console.Write("ID do Fornecedor: ");
        int fornecedorId;
        while (!int.TryParse(Console.ReadLine(), out fornecedorId))
        {
            Console.WriteLine("Por favor, insira um número válido para o ID do fornecedor.");
            Console.Write("ID do Fornecedor: ");
        }

        try
        {
            controleFazenda.InserirMateriaPrima(tipo, ativo, nome, imagemId, fornecedorId);
            Console.WriteLine("Matéria-Prima inserida com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao inserir a matéria-prima: " + ex.Message);
        }
    }

    public void ListarMateriasPrimas()
    {
        string connectionString = "Data Source=localhost;Initial Catalog=MicroGreenDB;Integrated Security=True;";
        ControleFazendaUrbana controleFazenda = new ControleFazendaUrbana(connectionString);

        Console.WriteLine("=== Listar Matérias-Primas ===");
        try
        {
            List<MateriaPrima> materiasPrimas = controleFazenda.SelecionarTodasMateriasPrimas();
            foreach (MateriaPrima materiaPrima in materiasPrimas)
            {
                Console.WriteLine($"ID: {materiaPrima.MateriaPrimaId}");
                Console.WriteLine($"Tipo: {materiaPrima.Tipo}");
                Console.WriteLine($"Ativo: {materiaPrima.Ativo}");
                Console.WriteLine($"Nome: {materiaPrima.Nome}");
                Console.WriteLine($"Imagem ID: {materiaPrima.ImagemId}");
                Console.WriteLine($"Fornecedor ID: {materiaPrima.FornecedorId}");
                Console.WriteLine(new string('-', 40)); // Linha separadora
                Console.ReadLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao listar as matérias-primas: " + ex.Message);
        }
    }

    public void AtualizarMateriaPrima()
    {
        string connectionString = "Data Source=localhost;Initial Catalog=MicroGreenDB;Integrated Security=True;";
        ControleFazendaUrbana controleFazenda = new ControleFazendaUrbana(connectionString);

        Console.WriteLine("=== Atualizar Matéria-Prima ===");

        Console.Write("ID da Matéria-Prima: ");
        int materiaPrimaId;
        while (!int.TryParse(Console.ReadLine(), out materiaPrimaId))
        {
            Console.WriteLine("Por favor, insira um número válido para o ID da matéria-prima.");
            Console.Write("ID da Matéria-Prima: ");
        }

        Console.Write("Novo Tipo: ");
        string novoTipo = Console.ReadLine();

        Console.Write("Novo Nome: ");
        string novoNome = Console.ReadLine();

        Console.Write("Novo Ativo (true/false): ");
        bool novoAtivo;
        while (!bool.TryParse(Console.ReadLine(), out novoAtivo))
        {
            Console.WriteLine("Por favor, insira 'true' ou 'false'.");
            Console.Write("Novo Ativo (true/false): ");
        }

        Console.Write("Novo ID da Imagem: ");
        int novoImagemId;
        while (!int.TryParse(Console.ReadLine(), out novoImagemId))
        {
            Console.WriteLine("Por favor, insira um número válido para o ID da imagem.");
            Console.Write("Novo ID da Imagem: ");
        }

        Console.Write("Novo ID do Fornecedor: ");
        int novoFornecedorId;
        while (!int.TryParse(Console.ReadLine(), out novoFornecedorId))
        {
            Console.WriteLine("Por favor, insira um número válido para o ID do fornecedor.");
            Console.Write("Novo ID do Fornecedor: ");
        }

        try
        {
            controleFazenda.AtualizarMateriaPrima(materiaPrimaId, novoTipo, novoAtivo, novoNome, novoImagemId, novoFornecedorId);
            Console.WriteLine("Matéria-Prima atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao atualizar a matéria-prima: " + ex.Message);
        }
    }

    public void DeletarMateriaPrima()
    {
        string connectionString = "Data Source=localhost;Initial Catalog=MicroGreenDB;Integrated Security=True;";
        ControleFazendaUrbana controleFazenda = new ControleFazendaUrbana(connectionString);

        Console.WriteLine("=== Deletar Matéria-Prima ===");
        Console.Write("ID da Matéria-Prima: ");
        int materiaPrimaId;
        while (!int.TryParse(Console.ReadLine(), out materiaPrimaId))
        {
            Console.WriteLine("Por favor, insira um número válido para o ID da matéria-prima.");
            Console.Write("ID da Matéria-Prima: ");
        }

        try
        {
            controleFazenda.ExcluirMateriaPrima(materiaPrimaId);
            Console.WriteLine("Matéria-Prima excluída com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao excluir a matéria-prima: " + ex.Message);
        }
    }
}

