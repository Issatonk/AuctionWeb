CREATE TABLE [dbo].[FileModel] (
    [Id]    INT              IDENTITY (1, 1) NOT NULL,
    [lotId] UNIQUEIDENTIFIER NOT NULL,
    [Path]  NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_FileModel] PRIMARY KEY CLUSTERED ([Id] ASC)
);

