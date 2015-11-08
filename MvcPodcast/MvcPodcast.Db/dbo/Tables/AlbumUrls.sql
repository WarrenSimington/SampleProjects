CREATE TABLE [dbo].[AlbumUrls] (
    [Id]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [AlbumId]     BIGINT        NOT NULL,
    [DisplayText] VARCHAR (MAX) NOT NULL,
    [Url]         VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_AlbumUrls] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AlbumUrls_Albums] FOREIGN KEY ([AlbumId]) REFERENCES [dbo].[Albums] ([Id])
);

