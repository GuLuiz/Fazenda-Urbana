-- Inserir Matéria Prima
CREATE PROCEDURE InserirMateriaPrima
    @Tipo VARCHAR(50),
    @Ativo BIT,
    @Nome VARCHAR(100),
    @Imagem_Id INT,
    @Fornecedor_Id INT
AS
BEGIN
    INSERT INTO Materia_Prima (Tipo, Ativo, Nome, Imagem_Id, Fornecedor_Id)
    VALUES (@Tipo, @Ativo, @Nome, @Imagem_Id, @Fornecedor_Id);
END;
GO

-- Atualizar Matéria Prima
CREATE PROCEDURE AtualizarMateriaPrima
    @MateriaPrimaId INT,
    @Tipo VARCHAR(50),
    @Ativo BIT,
    @Nome VARCHAR(100),
    @Imagem_Id INT,
    @Fornecedor_Id INT
AS
BEGIN
    UPDATE Materia_Prima
    SET Tipo = @Tipo,
        Ativo = @Ativo,
        Nome = @Nome,
        Imagem_Id = @Imagem_Id,
        Fornecedor_Id = @Fornecedor_Id
    WHERE materia_prima_ID = @MateriaPrimaId;
END;
GO

-- Excluir Matéria Prima
CREATE PROCEDURE ExcluirMateriaPrima
    @MateriaPrimaId INT
AS
BEGIN
    DELETE FROM Materia_Prima
    WHERE materia_prima_ID = @MateriaPrimaId;
END;
GO

-- Selecionar todas as Matéria Prima
CREATE PROCEDURE SelecionarTodasMateriasPrimas
AS
BEGIN
    SELECT * FROM Materia_Prima;
END;
GO
