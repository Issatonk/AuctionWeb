CREATE TABLE [dbo].[Bets] (
    [Id]     INT              IDENTITY (1, 1) NOT NULL,
    [ManId]  UNIQUEIDENTIFIER NOT NULL,
    [LotsId] UNIQUEIDENTIFIER NOT NULL,
    [Price]  FLOAT (53)       NOT NULL,
    [Time]   DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_Bets] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Bets_Lots_LotsId] FOREIGN KEY ([LotsId]) REFERENCES [dbo].[Lots] ([Id]),
    CONSTRAINT [FK_Bets_Users_ManId] FOREIGN KEY ([ManId]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Bets_LotsId]
    ON [dbo].[Bets]([LotsId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Bets_ManId]
    ON [dbo].[Bets]([ManId] ASC);

