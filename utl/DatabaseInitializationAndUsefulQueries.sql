--- Database initial setup! WARNING: this commands will erase the existing database configurations
CREATE DATABASE ErpDb;

USE ErpDb;

DROP TABLE IF EXISTS [dbo].[Collaborators];

CREATE TABLE [dbo].[Collaborators] (
    [Id]             INT                      IDENTITY (1, 1)   NOT NULL,
    [PublicId]       UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() NOT NULL,
    [FirstName]      NVARCHAR (50)                              NOT NULL,
    [LastName]       NVARCHAR (50)                              NOT NULL,
	[Birthday]       DATE                                       NULL,
    [DocumentNumber] BIGINT                                     NOT NULL,
    [DocumentType]   NVARCHAR (50)                              NOT NULL,
    [HiredAt]        DATE                                       NOT NULL,
    [ResignationAt]  DATE                                       NULL,
    CONSTRAINT [PK_Collaborators] PRIMARY KEY CLUSTERED ([Id] ASC)
);

--------------------------------------
-- Inject some data for test purposes
INSERT [dbo].[Collaborators] ([FirstName], [LastName], [Birthday], [DocumentNumber], [DocumentType], [HiredAt], [ResignationAt])
    VALUES (N'FirstOne', N'Surname1', NULL, 12345678901, N'CPF', '2018-12-10', NULL);
INSERT [dbo].[Collaborators] ([FirstName], [LastName], [Birthday], [DocumentNumber], [DocumentType], [HiredAt], [ResignationAt])
    VALUES (N'SecondOne', N'Surname2', NULL, 22345678902, N'CPF', '2018-12-10', NULL);
INSERT [dbo].[Collaborators] ([FirstName], [LastName], [Birthday], [DocumentNumber], [DocumentType], [HiredAt], [ResignationAt])
    VALUES (N'ThirdOne', N'Surname3', NULL, 32345678903, N'CPF', '2018-12-10', NULL);


----------------------------------------------------
----------------------------------------------------
--- Optional:
--- Useful queries

-- Describe table
exec sp_columns Collaborators;

-- Insert register
INSERT [dbo].[Collaborators] ([FirstName], [LastName], [Birthday], [DocumentNumber], [DocumentType], [HiredAt], [ResignationAt])
    VALUES (N'FirstOne', N'Surname1', NULL, 12345678901, N'CPF', '2018-12-10', NULL);

-- Get all collaborators
select * from Collaborators;