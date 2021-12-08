CREATE TABLE [dbo].[SellHistories] (
    [Id]      INT              IDENTITY (1, 1) NOT NULL,
    [LotId]   UNIQUEIDENTIFIER NOT NULL,
    [OwnerId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_SellHistories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

