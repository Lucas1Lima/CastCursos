IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categorias] (
    [IDCategoria] int NOT NULL IDENTITY,
    [CategoriaExiste] nvarchar(max) NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY ([IDCategoria])
);
GO

CREATE TABLE [Cursos] (
    [ID] int NOT NULL IDENTITY,
    [Descricao] nvarchar(max) NOT NULL,
    [DataInicio] datetime2 NOT NULL,
    [DataFinal] datetime2 NOT NULL,
    [IDCategoria] int NOT NULL,
    [IDUsuario] int NOT NULL,
    [QtdAlunos] int NOT NULL,
    CONSTRAINT [PK_Cursos] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [Usuario] (
    [IDUsuario] int NOT NULL IDENTITY,
    [NomeUsuario] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Senha] nvarchar(max) NULL,
    [Adm] bit NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([IDUsuario])
);
GO

CREATE TABLE [Logs] (
    [IDLog] int NOT NULL IDENTITY,
    [Tipo] int NOT NULL,
    [Data] datetime2 NOT NULL,
    [CursoID] int NULL,
    CONSTRAINT [PK_Logs] PRIMARY KEY ([IDLog]),
    CONSTRAINT [FK_Logs_Cursos_CursoID] FOREIGN KEY ([CursoID]) REFERENCES [Cursos] ([ID]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Logs_CursoID] ON [Logs] ([CursoID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211118125818_Acao', N'5.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Logs] ADD [IDCurso] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Logs] ADD [IDUsuario] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211118130130_Acao_2', N'5.0.12');
GO

COMMIT;
GO

