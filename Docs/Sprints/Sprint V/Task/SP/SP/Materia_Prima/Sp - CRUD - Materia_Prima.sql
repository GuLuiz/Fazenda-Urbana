-- Inserir um novo Insumo
EXEC InserirMateriaPrima 
    @Tipo = 'Substrato',
    @Ativo = 1,
    @Nome = 'Substrato Orgânico para Hidroponia',
    @Imagem_Id = 1,
    @Fornecedor_Id = 1;

-- Atualizar um Insumo existente
EXEC AtualizarMateriaPrima 
    @MateriaPrimaId = 1,
    @Tipo = 'Nutrientes',
    @Ativo = 1, 
    @Nome = 'Fertilizante para Plantas Verdes',
    @Imagem_Id = 2, 
    @Fornecedor_Id = 1;

-- Excluir um Insumo pelo ID
--EXEC ExcluirMateriaPrima 
    -- @MateriaPrimaId = 1;

-- Selecionar todos os Insumos
EXEC SelecionarTodasMateriasPrimas;
