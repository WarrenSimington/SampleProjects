CREATE TABLE [Library].[Workstations] (
    [Id]   BIGINT       IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (25) NOT NULL,
    CONSTRAINT [PK_Workstations] PRIMARY KEY CLUSTERED ([Id] ASC)
);

