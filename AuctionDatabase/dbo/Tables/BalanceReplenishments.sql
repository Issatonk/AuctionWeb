CREATE TABLE [dbo].[BalanceReplenishments] (
    [Id]     INT              IDENTITY (1, 1) NOT NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [Amount] FLOAT (53)       NOT NULL,
    [Date]   DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_BalanceReplenishments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BalanceReplenishments_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BalanceReplenishments_UserId]
    ON [dbo].[BalanceReplenishments]([UserId] ASC);

