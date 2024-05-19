-- Procedure para inserir uma nova produção
/*EXEC InserirProducao 
    @Quantidade = 100,
    @TempoCultivacao = 10,
    @Ativo = 1,
    @DiasRestantes = 5,
    @MateriaPrimaId = 2,
    @FuncionarioId = 1;
GO*/

-- Procedure para atualizar uma produção existente
EXEC AtualizarProducao 
    @ProducaoId = 3,
    @Quantidade = 150,
    @TempoCultivacao = 12,
    @Ativo = 1,
    @DiasRestantes = 4,
    @MateriaPrimaId = 2,
    @FuncionarioId = 1;
GO

-- Procedure para excluir uma produção pelo ID
--EXEC ExcluirProducao 
 --   @ProducaoId = 1;
-- GO

-- Procedure para selecionar todas as produções
EXEC SelecionarTodasProducoes;
GO
