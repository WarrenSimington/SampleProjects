CREATE TABLE [Library].[Albums] (
    [Title]          VARCHAR (MAX)    NOT NULL,
    [ArtistId]       BIGINT           NOT NULL,
    [Id]             UNIQUEIDENTIFIER CONSTRAINT [DF_Albums_Id] DEFAULT (newsequentialid()) NOT NULL,
    [Directory]      VARCHAR (MAX)    NOT NULL,
    [WmCollectionId] VARCHAR (MAX)    NOT NULL,
    CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Albums_Artists] FOREIGN KEY ([ArtistId]) REFERENCES [Library].[Artists] ([Id])
);







