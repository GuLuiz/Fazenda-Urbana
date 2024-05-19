-- sp - crud - fornecedores


/* EXEC InserirFornecedor 
    @Cnpj = '12345678901234',
    @RazaoSocial = 'Empresa ABC Ltda.',
    @Ativo = 1, 
    @Cidade = 'São Paulo',
    @Estado = 'SP',
    @Pais = 'Brasil',
    @InscricaoEstadual = '123.456.789',
    @ContatosPrincipal = 'João Silva';
	*/
EXEC AtualizarFornecedor 
    @FornecedorId = 1, -- Supondo que o ID do fornecedor a ser atualizado seja 1
    @Cnpj = '98765432109876',
    @RazaoSocial = 'Empresa XY S.A.',
    @Ativo = 0,
    @Cidade = 'Rio de Janeiro',
    @Estado = 'RJ',
    @Pais = 'Brasil',
    @InscricaoEstadual = '987.654.321',
    @ContatosPrincipal = 'Maria Oliveira';

-- EXEC ExcluirFornecedor 
   -- @FornecedorId = 1; -- ID do Fornecedor a ser excluído

EXEC SelecionarTodosFornecedores;

