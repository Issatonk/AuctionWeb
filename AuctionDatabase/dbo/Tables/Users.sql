CREATE TABLE [dbo].[Users] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Name]     NVARCHAR (50)    NOT NULL,
    [Password] NVARCHAR (50)    NOT NULL,
    [Balance]  FLOAT (53)       NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

