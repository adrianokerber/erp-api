--- Database initialization query
CREATE TABLE [dbo].[Collaborators] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [LastName]  NVARCHAR (60) NOT NULL,
    [Document]  NVARCHAR (50) NOT NULL
);

--- Useful queries

-- Describe table
exec sp_columns Collaborators;

-- Insert register
INSERT [dbo].[Collaborators] ([FirstName], [LastName], [Document]) VALUES (N'Adriano', N'Kerber', N'A12345')

-- Get all collaborators
select * from Collaborators;