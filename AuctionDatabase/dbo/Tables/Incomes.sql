CREATE TABLE [dbo].[Incomes] (
    [Id]        DATETIME2 (7) NOT NULL,
    [IncomeSum] FLOAT (53)    NOT NULL,
    CONSTRAINT [PK_Incomes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

