CREATE TABLE [Library].[UpdateLog] (
    [Id]      BIGINT   IDENTITY (1, 1) NOT NULL,
    [Updated] DATETIME NOT NULL,
    CONSTRAINT [PK_UpdateLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);

