CREATE OR ALTER TRIGGER TriggerLogAlt
ON Fornecedores
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Acao VARCHAR(10);
    DECLARE @Tabela VARCHAR(20) = 'Fornecedores';
    DECLARE @Descricao VARCHAR(255);
    DECLARE @DataHora DATETIME = GETDATE();
    DECLARE @ID INT;
    DECLARE @NomeFornecedor VARCHAR(100);

    -- Verificar a ação realizada (INSERT, UPDATE, DELETE)
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @Acao = 'UPDATE';
    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @Acao = 'INSERT';
    ELSE IF EXISTS (SELECT * FROM deleted)
        SET @Acao = 'DELETE';

    -- Capturar o ID e Nome do fornecedor afetado
    IF @Acao = 'INSERT'
    BEGIN
        SELECT @ID = fornecedor_id, @NomeFornecedor = razao_social FROM inserted;
    END
    ELSE IF @Acao = 'UPDATE'
    BEGIN
        SELECT @ID = fornecedor_id, @NomeFornecedor = razao_social FROM inserted;
    END
    ELSE IF @Acao = 'DELETE'
    BEGIN
        SELECT @ID = fornecedor_id, @NomeFornecedor = razao_social FROM deleted;
    END

    -- Montar a descrição da alteração com o nome do fornecedor
    IF @Acao = 'INSERT'
        SET @Descricao = 'Inserido novo fornecedor :  ' + @NomeFornecedor + '.';
    ELSE IF @Acao = 'UPDATE'
        SET @Descricao = 'Atualizado fornecedor : ' + @NomeFornecedor + '.';
    ELSE IF @Acao = 'DELETE'
        SET @Descricao = 'Excluído fornecedor : ' + @NomeFornecedor + '.';

    -- Registrar a alteração na tabela de log
    INSERT INTO Log_Alt (Acao, Tabela, Descricao, DataHora, Id)
    VALUES (@Acao, @Tabela, @Descricao, @DataHora, @ID);
END;
