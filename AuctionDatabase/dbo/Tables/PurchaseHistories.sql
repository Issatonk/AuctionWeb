CREATE TABLE [dbo].[PurchaseHistories] (
    [Id]      INT              IDENTITY (1, 1) NOT NULL,
    [LotId]   UNIQUEIDENTIFIER NOT NULL,
    [OwnerId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_PurchaseHistories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

