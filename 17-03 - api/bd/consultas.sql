USE Session2
GO

-- Itens do roteiro.txt

-- 3 - Listar os primeiros 500 participantes em SQL
SELECT TOP (500) [id]
				,[nome]
				,[idade]
				,[cidadeId]
				,[genero]
FROM [Session2].[dbo].[participante]
GO

-- 4 - Ordenar os participantes por nome em SQL
SELECT TOP (500) [id]
				,[nome]
				,[idade]
				,[cidadeId]
				,[genero]
FROM [Session2].[dbo].[participante]
ORDER BY nome
GO

-- 5 - Buscar participantes por nome completo em SQL 
SELECT TOP (500) [id]
				,[nome]
				,[idade]
				,[cidadeId]
				,[genero]
FROM [Session2].[dbo].[participante]
WHERE nome = 'ABADIO JURIEL'
ORDER BY nome
GO

-- 6 - Buscar participantes de um determinado estado com a instrução JOIN em SQL
SELECT TOP (500) participante.id
				,[nome]
				,[idade]
				,[cidadeId]
				,[genero]
				,[Sigla]
FROM [Session2].[dbo].[participante]
INNER JOIN [cidade] ON cidade.id = participante.cidadeId
INNER JOIN [estado] ON estado.id = cidade.estadoId
WHERE Sigla = 'SP'
ORDER BY nome
GO

-- 7 - Buscar participantes por filtro de string com a instrução LIKE em SQL
SELECT TOP (500) participante.id
				,[nome]
				,[idade]
				,[cidadeId]
				,[genero]
FROM [Session2].[dbo].[participante]
WHERE nome LIKE '%RT'
ORDER BY nome
GO

-- 8 - Ordenar participantes por nome ou pontos crescente em SQL
SELECT TOP (500) participante.id
				,[nome]
				,[idade]
				,[cidadeId]
				,[genero]
FROM [Session2].[dbo].[participante]
ORDER BY nome ASC
GO

-- 9 - Ordenar participantes por nome ou pontos descrecente em SQL
SELECT TOP (500) participante.id
				,[nome]
				,[idade]
				,[cidadeId]
				,[genero]
FROM [Session2].[dbo].[participante]
ORDER BY nome DESC
GO