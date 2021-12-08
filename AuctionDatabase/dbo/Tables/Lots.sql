CREATE TABLE [dbo].[Lots] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [OwnerID]      UNIQUEIDENTIFIER NOT NULL,
    [Name]         NVARCHAR (50)    NOT NULL,
    [Description]  NVARCHAR (300)   NOT NULL,
    [CurrentPrice] FLOAT (53)       NOT NULL,
    [FinalDate]    DATETIME2 (7)    NOT NULL,
    [Category]     NVARCHAR (MAX)   DEFAULT (N'') NOT NULL,
    [PathPhoto]    NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Lots] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Lots_Users_OwnerID] FOREIGN KEY ([OwnerID]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Lots_OwnerID]
    ON [dbo].[Lots]([OwnerID] ASC);

