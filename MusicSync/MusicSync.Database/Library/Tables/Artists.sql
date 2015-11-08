CREATE TABLE [Library].[Artists] (
    [Id]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED ([Id] ASC)
);



