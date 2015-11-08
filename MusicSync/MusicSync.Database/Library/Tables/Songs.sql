CREATE TABLE [Library].[Songs] (
    [Id]          BIGINT           IDENTITY (1, 1) NOT NULL,
    [Title]       VARCHAR (MAX)    NOT NULL,
    [TrackingId]  UNIQUEIDENTIFIER NOT NULL,
    [Duration]    FLOAT (53)       NOT NULL,
    [DateAdded]   DATETIME2 (7)    NOT NULL,
    [ReleaseDate] DATE             NULL,
    [TrackNumber] INT              NOT NULL,
    [SourceURL]   VARCHAR (MAX)    NOT NULL,
    [AlbumId]     UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Songs] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Songs_Albums] FOREIGN KEY ([AlbumId]) REFERENCES [Library].[Albums] ([Id])
);





















