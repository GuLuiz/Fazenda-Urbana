-- TRIGGER para registrar alterações na tabela de Produção
CREATE OR ALTER TRIGGER TriggerLogAlteracoesProducao
ON Producao
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Acao VARCHAR(10);
    DECLARE @Descricao VARCHAR(255);
    DECLARE @DataHora DATETIME = GETDATE();
    DECLARE @ID INT;
    DECLARE @NomeProducao VARCHAR(100);
    DECLARE @Tabela VARCHAR(20) = 'Producao';

    -- Verificar a ação realizada (INSERT, UPDATE, DELETE)
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @Acao = 'UPDATE';
    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @Acao = 'INSERT';
    ELSE IF EXISTS (SELECT * FROM deleted)
        SET @Acao = 'DELETE';

    -- Capturar o ID e Nome da Produção afetada
    IF @Acao IN ('INSERT', 'UPDATE')
    BEGIN
        SELECT @ID = producao_id, @NomeProducao = materia_prima_id FROM inserted;
    END
    ELSE IF @Acao = 'DELETE'
    BEGIN
        SELECT @ID = producao_id, @NomeProducao = materia_prima_id FROM deleted;
    END;

    -- Montar a descrição da alteração com o nome da Produção
    IF @Acao = 'INSERT'
        SET @Descricao = 'Inserida nova produção da materia prima :  ' + @NomeProducao + '.';
    ELSE IF @Acao = 'UPDATE'
        SET @Descricao = 'Atualizada produção da materia prima : ' + @NomeProducao + '.';
    ELSE IF @Acao = 'DELETE'
        SET @Descricao = 'Excluída produção da materia prima : ' + @NomeProducao + '.';

    -- Registrar a alteração na tabela de log
    INSERT INTO Log_Alt (Acao, Tabela, Descricao, DataHora, Id)
    VALUES (@Acao, @Tabela, @Descricao, @DataHora, @ID);
END;
