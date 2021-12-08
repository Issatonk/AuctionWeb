CREATE TABLE [dbo].[SellLots] (
    [Id]    INT              IDENTITY (1, 1) NOT NULL,
    [LotId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_SellLots] PRIMARY KEY CLUSTERED ([Id] ASC)
);

