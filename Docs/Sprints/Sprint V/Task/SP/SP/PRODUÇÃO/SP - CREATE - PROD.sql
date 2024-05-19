-- Procedure para inserir uma nova produção
CREATE OR ALTER PROCEDURE InserirProducao 
    @Quantidade INT,
    @TempoCultivacao INT,
    @Ativo BIT,
    @DiasRestantes INT,
    @MateriaPrimaId INT,
    @FuncionarioId INT
AS
BEGIN
    INSERT INTO Producao (quantidade, tempo_cultivacao, ativo, dias_restantes, materia_prima_id, funcionario_id)
    VALUES (@Quantidade, @TempoCultivacao, @Ativo, @DiasRestantes, @MateriaPrimaId, @FuncionarioId);
END;
GO

-- Procedure para atualizar uma produção existente
CREATE OR ALTER PROCEDURE AtualizarProducao 
    @ProducaoId INT,
    @Quantidade INT,
    @TempoCultivacao INT,
    @Ativo BIT,
    @DiasRestantes INT,
    @MateriaPrimaId INT,
    @FuncionarioId INT
AS
BEGIN
    UPDATE Producao 
    SET quantidade = @Quantidade,
        tempo_cultivacao = @TempoCultivacao,
        ativo = @Ativo,
        dias_restantes = @DiasRestantes,
        materia_prima_id = @MateriaPrimaId,
        funcionario_id = @FuncionarioId
    WHERE producao_id = @ProducaoId;
END;
GO

-- Procedure para excluir uma produção pelo ID
CREATE OR ALTER PROCEDURE ExcluirProducao 
    @ProducaoId INT
AS
BEGIN
    DELETE FROM Producao WHERE producao_id = @ProducaoId;
END;
GO

-- Procedure para selecionar todas as produções
CREATE OR ALTER PROCEDURE SelecionarTodasProducoes
AS
BEGIN
    SELECT * FROM Producao;
END;
GO
