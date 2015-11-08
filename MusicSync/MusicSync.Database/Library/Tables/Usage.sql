CREATE TABLE [Library].[Usage] (
    [MachineId]      BIGINT           NOT NULL,
    [SongTrackingId] UNIQUEIDENTIFIER NOT NULL,
    [LastPlayed]     DATETIME         NULL,
    [Id]             BIGINT           IDENTITY (1, 1) NOT NULL,
    [SongId]         BIGINT           NOT NULL,
    CONSTRAINT [PK_Usage] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Usage_Songs] FOREIGN KEY ([SongId]) REFERENCES [Library].[Songs] ([Id]),
    CONSTRAINT [FK_Usage_Workstations] FOREIGN KEY ([MachineId]) REFERENCES [Library].[Workstations] ([Id])
);







