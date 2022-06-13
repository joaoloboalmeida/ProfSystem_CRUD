--sp para ajustar valor do Id IDENTITY quando houver alguma exclusão no banco 

USE [ProfSystem]
GO

CREATE OR ALTER PROCEDURE [spResetIdentityId]
    @tblName VARCHAR(100), @Id INT
    AS
        DBCC CHECKIDENT(@tblName, RESEED, @Id)

GO