CREATE TABLE [User] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(80) NOT NULL,
    [Email] VARCHAR(255) NOT NULL,
    [PasswordHash] VARCHAR(255) NOT NULL,
    [Bio] NVARCHAR(MAX) NOT NULL,
    [Image] VARCHAR(2000) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,

    CONSTRAINT [PK_User] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_User_Email] UNIQUE([Email]),
    CONSTRAINT [UQ_User_Slug] UNIQUE([Slug])
)

CREATE NONCLUSTERED INDEX [IX_User_Email] ON [User]([Email])
CREATE NONCLUSTERED INDEX [IX_User_Slug] ON [User]([Slug])

/*
 * NONCLUSTERED: Ao usar um índice não clusterizado, criamos uma estrutura separada que
 * organiza os valores da coluna indexada, e essa estrutura contém ponteiros que direcionam
 * para as linhas correspondentes na tabela original. A tabela em si **não é reorganizada fisicamente**.
 *
 * Já quando criamos um índice **clusterizado** (o índice normal), ele **organiza fisicamente toda a tabela**
 * de acordo com os valores da coluna indexada. A ordem das linhas da tabela é alterada para refletir a
 * ordem dos valores dessa coluna. Apenas **um índice clusterizado pode existir por tabela**.
 *
 * Por padrão quando criamos uma PRIMARY KEY, elá já é um index clusterizado e os próximos INDEX
 * serão não clusterizados
 */
