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