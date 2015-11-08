CREATE TABLE [dbo].[Podcasts] (
    [Id]                  BIGINT        IDENTITY (1, 1) NOT NULL,
    [ArticleId]           BIGINT        NOT NULL,
    [Album1Id]            BIGINT        NOT NULL,
    [Album2Id]            BIGINT        NOT NULL,
    [DownloadDisplayText] VARCHAR (MAX) NOT NULL,
    [DownloadUrl]         VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Podcasts] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Podcasts_Albums_Album1] FOREIGN KEY ([Album1Id]) REFERENCES [dbo].[Albums] ([Id]),
    CONSTRAINT [FK_Podcasts_Albums_Album2] FOREIGN KEY ([Album2Id]) REFERENCES [dbo].[Albums] ([Id]),
    CONSTRAINT [FK_Podcasts_Articles] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Articles] ([Id])
);

