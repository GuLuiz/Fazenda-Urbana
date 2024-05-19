-- Procedure para inserir uma nova produ��o
/*EXEC InserirProducao 
    @Quantidade = 100,
    @TempoCultivacao = 10,
    @Ativo = 1,
    @DiasRestantes = 5,
    @MateriaPrimaId = 2,
    @FuncionarioId = 1;
GO*/

-- Procedure para atualizar uma produ��o existente
EXEC AtualizarProducao 
    @ProducaoId = 3,
    @Quantidade = 150,
    @TempoCultivacao = 12,
    @Ativo = 1,
    @DiasRestantes = 4,
    @MateriaPrimaId = 2,
    @FuncionarioId = 1;
GO

-- Procedure para excluir uma produ��o pelo ID
--EXEC ExcluirProducao 
 --   @ProducaoId = 1;
-- GO

-- Procedure para selecionar todas as produ��es
EXEC SelecionarTodasProducoes;
GO
