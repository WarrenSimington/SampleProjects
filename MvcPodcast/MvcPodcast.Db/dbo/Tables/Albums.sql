CREATE TABLE [dbo].[Albums] (
    [Id]                 BIGINT        IDENTITY (1, 1) NOT NULL,
    [Artist]             VARCHAR (MAX) NOT NULL,
    [Caption]            VARCHAR (50)  NOT NULL,
    [CoverImageFileName] VARCHAR (260) NOT NULL,
    [Label]              VARCHAR (50)  NULL,
    [Title]              VARCHAR (MAX) NOT NULL,
    [Year]               INT           NOT NULL,
    CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED ([Id] ASC)
);



