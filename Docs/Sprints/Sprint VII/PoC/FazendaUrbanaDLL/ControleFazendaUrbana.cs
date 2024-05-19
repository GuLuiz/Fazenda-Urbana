using FazendaUrbanaDLL.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace FazendaUrbanaDLL;

public class ControleFazendaUrbana
{
    private string ConnectionString;
    //Conexão do DB  : "Data Source=localhost;Initial Catalog=MicroGreenDB;Integrated Security=True;"
    public ControleFazendaUrbana(string connectionString)
    {
        this.ConnectionString = connectionString;
    }
   
    //Crud Fornecedor
        public void InserirFornecedor(string cnpj,
            string razaoSocial,
            bool ativo, string cidade,
            string estado, string pais,
            string inscricaoEstadual,
            string contatosPrincipal)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("InserirFornecedor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Cnpj", cnpj);
                    command.Parameters.AddWithValue("@RazaoSocial", razaoSocial);
                    command.Parameters.AddWithValue("@Ativo", ativo);
                    command.Parameters.AddWithValue("@Cidade", cidade);
                    command.Parameters.AddWithValue("@Estado", estado);
                    command.Parameters.AddWithValue("@Pais", pais);
                    command.Parameters.AddWithValue("@InscricaoEstadual", inscricaoEstadual);
                    command.Parameters.AddWithValue("@ContatosPrincipal", contatosPrincipal);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Fornecedor> SelecionarTodosFornecedores()
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SelecionarTodosFornecedores", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Fornecedor fornecedor = new Fornecedor
                                {
                                    FornecedorId = reader.GetInt32(reader.GetOrdinal("fornecedor_ID")),
                                    Cnpj = reader.IsDBNull(reader.GetOrdinal("cnpj")) ? null : reader.GetString(reader.GetOrdinal("cnpj")),
                                    RazaoSocial = reader.IsDBNull(reader.GetOrdinal("razao_social")) ? null : reader.GetString(reader.GetOrdinal("razao_social")),
                                    Ativo = reader.GetBoolean(reader.GetOrdinal("ativo")),
                                    Cidade = reader.IsDBNull(reader.GetOrdinal("cidade")) ? null : reader.GetString(reader.GetOrdinal("cidade")),
                                    Estado = reader.IsDBNull(reader.GetOrdinal("estado")) ? null : reader.GetString(reader.GetOrdinal("estado")),
                                    Pais = reader.IsDBNull(reader.GetOrdinal("pais")) ? null : reader.GetString(reader.GetOrdinal("pais")),
                                    InscricaoEstadual = reader.IsDBNull(reader.GetOrdinal("inscricao_estadual")) ? null : reader.GetString(reader.GetOrdinal("inscricao_estadual")),
                                    ContatosPrincipal = reader.IsDBNull(reader.GetOrdinal("contatos_principal")) ? null : reader.GetString(reader.GetOrdinal("contatos_principal"))
                                };
                                fornecedores.Add(fornecedor);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex) //Exception relacionada ao SQL
            {
                throw new ApplicationException("Erro ao acessar o banco de dados: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao processar dados: " + ex.Message);
            }

            return fornecedores;
        }

        public void AtualizarFornecedor(int fornecedorId,
            string cnpj,
            string razaoSocial,
            bool ativo,
            string cidade,
            string estado,
            string pais,
            string inscricaoEstadual,
            string contatosPrincipal)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("AtualizarFornecedor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FornecedorId", fornecedorId);
                    command.Parameters.AddWithValue("@Cnpj", cnpj);
                    command.Parameters.AddWithValue("@RazaoSocial", razaoSocial);
                    command.Parameters.AddWithValue("@Ativo", ativo);
                    command.Parameters.AddWithValue("@Cidade", cidade);
                    command.Parameters.AddWithValue("@Estado", estado);
                    command.Parameters.AddWithValue("@Pais", pais);
                    command.Parameters.AddWithValue("@InscricaoEstadual", inscricaoEstadual);
                    command.Parameters.AddWithValue("@ContatosPrincipal", contatosPrincipal);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ExcluirFornecedor(int fornecedorId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("ExcluirFornecedor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FornecedorId", fornecedorId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

     //Crud Materia_Prima

    public void InserirMateriaPrima(string tipo,
        bool ativo,
        string nome,
        int imagemId,
        int fornecedorId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("InserirMateriaPrima", connection))
                {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Tipo", tipo);
                command.Parameters.AddWithValue("@Ativo", ativo);
                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@Imagem_Id", imagemId);
                command.Parameters.AddWithValue("@Fornecedor_Id", fornecedorId);

                connection.Open();
                command.ExecuteNonQuery();
                }
            }
        }

    public List<MateriaPrima> SelecionarTodasMateriasPrimas()
    {
        List<MateriaPrima> materiasPrimas = new List<MateriaPrima>();

        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SelecionarTodasMateriasPrimas", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MateriaPrima materiaPrima = new MateriaPrima
                            {
                                MateriaPrimaId = reader.GetInt32(reader.GetOrdinal("materia_prima_ID")),
                                Tipo = reader.IsDBNull(reader.GetOrdinal("Tipo")) ? null : reader.GetString(reader.GetOrdinal("Tipo")),
                                Ativo = reader.GetBoolean(reader.GetOrdinal("ativo")),
                                Nome = reader.IsDBNull(reader.GetOrdinal("nome")) ? null : reader.GetString(reader.GetOrdinal("nome")),
                                ImagemId = reader.GetInt32(reader.GetOrdinal("imagem_Id")),
                                FornecedorId = reader.GetInt32(reader.GetOrdinal("fornecedor_ID"))
                            };
                            materiasPrimas.Add(materiaPrima);
                        }
                    }
                }
            }
        }
        catch (SqlException ex) //Exception relacionada ao SQL
        {
            throw new ApplicationException("Erro ao acessar o banco de dados: " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Erro ao processar dados: " + ex.Message);
        }

        return materiasPrimas;
    }

    public void AtualizarMateriaPrima(int materiaPrimaId,
        string tipo,
        bool ativo,
        string nome,
        int imagemId,
        int fornecedorId)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("AtualizarMateriaPrima", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MateriaPrimaId", materiaPrimaId);
                command.Parameters.AddWithValue("@Tipo", tipo);
                command.Parameters.AddWithValue("@Ativo", ativo);
                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@ImagemId", imagemId);
                command.Parameters.AddWithValue("@FornecedorId", fornecedorId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    public void ExcluirMateriaPrima(int materiaPrimaId)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("ExcluirMateriaPrima", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MateriaPrimaId", materiaPrimaId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    //Crud Producao

    public void InserirProducao(int quantidade,
        int tempoCultivacao,
        bool ativo, int diasRestantes, 
        int materiaPrimaId
        , int funcionarioId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("InserirProducao", connection))
                {   
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Quantidade", quantidade);
                command.Parameters.AddWithValue("@TempoCultivacao", tempoCultivacao);
                command.Parameters.AddWithValue("@Ativo", ativo);
                command.Parameters.AddWithValue("@DiasRestantes", diasRestantes);
                command.Parameters.AddWithValue("@MateriaPrimaId", materiaPrimaId);
                command.Parameters.AddWithValue("@FuncionarioId", funcionarioId);

                connection.Open();
                command.ExecuteNonQuery();
                }
            }
        }

    public List<Producao> SelecionarTodasProducoes()
    {
        List<Producao> producoes = new List<Producao>();

        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SelecionarTodasProducoes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producao producao = new Producao
                            {
                                ProducaoId = reader.GetInt32(reader.GetOrdinal("producao_id")),
                                Quantidade = reader.GetInt32(reader.GetOrdinal("quantidade")),
                                TempoCultivacao = reader.GetInt32(reader.GetOrdinal("tempo_cultivacao")),
                                Ativo = reader.GetBoolean(reader.GetOrdinal("ativo")),
                                DiasRestantes = reader.GetInt32(reader.GetOrdinal("dias_restantes")),
                                MateriaPrimaId = reader.GetInt32(reader.GetOrdinal("materia_prima_id")),
                                FuncionarioId = reader.GetInt32(reader.GetOrdinal("funcionario_id"))
                            };
                            producoes.Add(producao);
                        }
                    }
                }
            }
        }
        catch (SqlException ex) //Exception relacionada ao SQL
        {
            throw new ApplicationException("Erro ao acessar o banco de dados: " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Erro ao processar dados: " + ex.Message);
        }

        return producoes;
    }

    public void AtualizarProducao(int producaoId, 
        int quantidade,
        int tempoCultivacao,
        bool ativo, int diasRestantes,
        int materiaPrimaId,
        int funcionarioId)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("AtualizarProducao", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProducaoId", producaoId);
                command.Parameters.AddWithValue("@Quantidade", quantidade);
                command.Parameters.AddWithValue("@TempoCultivacao", tempoCultivacao);
                command.Parameters.AddWithValue("@Ativo", ativo);
                command.Parameters.AddWithValue("@DiasRestantes", diasRestantes);
                command.Parameters.AddWithValue("@MateriaPrimaId", materiaPrimaId); // =1 
                command.Parameters.AddWithValue("@FuncionarioId", funcionarioId); // = 4

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    public void ExcluirProducao(int producaoId)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            using (SqlCommand command = new SqlCommand("ExcluirProducao", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProducaoId", producaoId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    public void GetPedidoDetalhes(int pedidoId)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {        
                using (SqlCommand command = new SqlCommand("MostrarPedidoDetalhes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pedido_id", pedidoId);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(
                                $" Pedido ID: {reader["pedido_id"]}\n" +
                                $" Quantidade: {reader["quantidade_pedido"]}\n" +
                                $" Cliente: {reader["nome_cliente"]}\n" +
                                $" Funcionário: {reader["nome_funcionario"]}\n" +
                                $" Produto: {reader["nome_produto"]}\n" +
                                $" Descrição: {reader["descricao_produto"]}\n" +
                                $" Ativo: {(bool)reader["ativo"]}");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao obter detalhes do pedido: {ex.Message}");
        }
    }
}
