-- TRIGGER para registrar altera��es na tabela de Produ��o
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

    -- Verificar a a��o realizada (INSERT, UPDATE, DELETE)
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @Acao = 'UPDATE';
    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @Acao = 'INSERT';
    ELSE IF EXISTS (SELECT * FROM deleted)
        SET @Acao = 'DELETE';

    -- Capturar o ID e Nome da Produ��o afetada
    IF @Acao IN ('INSERT', 'UPDATE')
    BEGIN
        SELECT @ID = producao_id, @NomeProducao = materia_prima_id FROM inserted;
    END
    ELSE IF @Acao = 'DELETE'
    BEGIN
        SELECT @ID = producao_id, @NomeProducao = materia_prima_id FROM deleted;
    END;

    -- Montar a descri��o da altera��o com o nome da Produ��o
    IF @Acao = 'INSERT'
        SET @Descricao = 'Inserida nova produ��o da materia prima :  ' + @NomeProducao + '.';
    ELSE IF @Acao = 'UPDATE'
        SET @Descricao = 'Atualizada produ��o da materia prima : ' + @NomeProducao + '.';
    ELSE IF @Acao = 'DELETE'
        SET @Descricao = 'Exclu�da produ��o da materia prima : ' + @NomeProducao + '.';

    -- Registrar a altera��o na tabela de log
    INSERT INTO Log_Alt (Acao, Tabela, Descricao, DataHora, Id)
    VALUES (@Acao, @Tabela, @Descricao, @DataHora, @ID);
END;
