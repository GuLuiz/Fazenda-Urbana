-- TRIGGER para registrar alterações na tabela de Matéria-Prima
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

    -- Verificar a ação realizada (INSERT, UPDATE, DELETE)
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @Acao = 'UPDATE';
    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @Acao = 'INSERT';
    ELSE IF EXISTS (SELECT * FROM deleted)
        SET @Acao = 'DELETE';

    -- Capturar o ID e Nome da matéria-prima afetada
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

    -- Montar a descrição da alteração com o nome da matéria-prima
    IF @Acao = 'INSERT'
        SET @Descricao = 'Inserida nova Matéria-Prima: ' + @NomeMateriaPrima + '.';
    ELSE IF @Acao = 'UPDATE'
        SET @Descricao = 'Atualizada Matéria-Prima: ' + @NomeMateriaPrima + '.';
    ELSE IF @Acao = 'DELETE'
        SET @Descricao = 'Excluída Matéria-Prima: ' + @NomeMateriaPrima + '.';

    -- Registrar a alteração na tabela de log
    INSERT INTO Log_Alt (Acao, Tabela, Descricao, DataHora, Id)
    VALUES (@Acao, @Tabela, @Descricao, @DataHora, @ID);
END;
