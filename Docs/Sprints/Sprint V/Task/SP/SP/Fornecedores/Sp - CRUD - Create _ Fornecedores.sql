-- Inserir Fornecedor
CREATE PROCEDURE InserirFornecedor
    @Cnpj VARCHAR(20),
    @RazaoSocial VARCHAR(100),
    @Ativo BIT,
    @Cidade VARCHAR(100),
    @Estado VARCHAR(50),
    @Pais VARCHAR(50),
    @InscricaoEstadual VARCHAR(50),
    @ContatosPrincipal VARCHAR(100)
AS
BEGIN
    INSERT INTO Fornecedores (cnpj, razao_social, ativo, cidade, estado, pais, inscricao_estadual, contatos_principal)
    VALUES (@Cnpj, @RazaoSocial, @Ativo, @Cidade, @Estado, @Pais, @InscricaoEstadual, @ContatosPrincipal);
END;
GO

-- Atualizar Fornecedor
CREATE PROCEDURE AtualizarFornecedor
    @FornecedorId INT,
    @Cnpj VARCHAR(20),
    @RazaoSocial VARCHAR(100),
    @Ativo BIT,
    @Cidade VARCHAR(100),
    @Estado VARCHAR(50),
    @Pais VARCHAR(50),
    @InscricaoEstadual VARCHAR(50),
    @ContatosPrincipal VARCHAR(100)
AS
BEGIN
    UPDATE Fornecedores
    SET cnpj = @Cnpj,
        razao_social = @RazaoSocial,
        ativo = @Ativo,
        cidade = @Cidade,
        estado = @Estado,
        pais = @Pais,
        inscricao_estadual = @InscricaoEstadual,
        contatos_principal = @ContatosPrincipal
    WHERE fornecedor_ID = @FornecedorId;
END;
GO

-- Excluir Fornecedor
CREATE PROCEDURE ExcluirFornecedor
    @FornecedorId INT
AS
BEGIN
    DELETE FROM Fornecedores
    WHERE fornecedor_ID = @FornecedorId;
END;
GO

-- Selecionar todos os Fornecedores
CREATE PROCEDURE SelecionarTodosFornecedores
AS
BEGIN
    SELECT * FROM Fornecedores;
END;
GO
