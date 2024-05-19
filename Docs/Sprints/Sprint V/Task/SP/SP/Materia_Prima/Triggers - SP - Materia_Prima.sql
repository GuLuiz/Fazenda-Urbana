-- TRIGGER para registrar altera��es na tabela de Mat�ria-Prima
CREATE OR ALTER TRIGGER TriggerLogAlteracoesMP
ON Materia_Prima
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Acao VARCHAR(10);
    DECLARE @Descricao VARCHAR(255);
    DECLARE @DataHora DATETIME = GETDATE();
    DECLARE @ID INT;
    DECLARE @NomeMateriaPrima VARCHAR(100);
    DECLARE @Tabela VARCHAR(20) = 'Materia_Prima';

    -- Verificar a a��o realizada (INSERT, UPDATE, DELETE)
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @Acao = 'UPDATE';
    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @Acao = 'INSERT';
    ELSE IF EXISTS (SELECT * FROM deleted)
        SET @Acao = 'DELETE';

    -- Capturar o ID e Nome da mat�ria-prima afetada
    IF @Acao = 'INSERT'
    BEGIN
        SELECT @ID = materia_prima_ID, @NomeMateriaPrima = nome FROM inserted;
    END
    ELSE IF @Acao = 'UPDATE'
    BEGIN
        SELECT @ID = materia_prima_ID, @NomeMateriaPrima = nome FROM inserted;
    END
    ELSE IF @Acao = 'DELETE'
    BEGIN
        SELECT @ID = materia_prima_ID, @NomeMateriaPrima = nome FROM deleted;
    END

    -- Montar a descri��o da altera��o com o nome da mat�ria-prima
    IF @Acao = 'INSERT'
        SET @Descricao = 'Inserida nova Mat�ria-Prima: ' + @NomeMateriaPrima + '.';
    ELSE IF @Acao = 'UPDATE'
        SET @Descricao = 'Atualizada Mat�ria-Prima: ' + @NomeMateriaPrima + '.';
    ELSE IF @Acao = 'DELETE'
        SET @Descricao = 'Exclu�da Mat�ria-Prima: ' + @NomeMateriaPrima + '.';

    -- Registrar a altera��o na tabela de log
    INSERT INTO Log_Alt (Acao, Tabela, Descricao, DataHora, Id)
    VALUES (@Acao, @Tabela, @Descricao, @DataHora, @ID);
END;
