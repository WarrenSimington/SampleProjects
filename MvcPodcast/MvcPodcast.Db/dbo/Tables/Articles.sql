CREATE TABLE [dbo].[Articles] (
    [Id]           BIGINT        IDENTITY (1, 1) NOT NULL,
    [PostDateTime] DATETIME      NOT NULL,
    [BodyText]     VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

