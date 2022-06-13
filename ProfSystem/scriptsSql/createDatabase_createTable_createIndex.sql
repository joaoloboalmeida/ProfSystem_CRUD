CREATE DATABASE [ProfSystem]
GO

USE [ProfSystem]
GO

BEGIN TRAN
CREATE TABLE [Professional] (
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] NVARCHAR(200) NOT NULL,
    [Phone] VARCHAR(21) NOT NULL,
    [Rg] VARCHAR(15) NOT NULL,
    [Address] NVARCHAR(250) NOT NULL,
    [Wage] DECIMAL(18,2) NOT NULL,
    [Hour] INT NOT NULL DEFAULT 0,
    [WageWithOvertime] DECIMAL(18,2) NOT NULL DEFAULT 0,

    CONSTRAINT [PK_Professional] PRIMARY KEY ([Id])
)

CREATE UNIQUE NONCLUSTERED INDEX [IX_Professional_Phone] ON [Professional]([Phone])
CREATE UNIQUE NONCLUSTERED INDEX [IX_Professional_Rg] ON [Professional]([Rg])
-- ROLLBACK
COMMIT