CREATE TABLE [dbo].[Currencys] (
    [Code]          NVARCHAR (450) NOT NULL,
    [Name]          NVARCHAR (MAX) NULL,
    [EnglishName]   NVARCHAR (MAX) NULL,
    [Nominal]       INT            NOT NULL,
    [ParentCode]    NVARCHAR (MAX) NULL,
    [IsoNumberCode] INT            NULL,
    [IsoCharCode]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Currencys] PRIMARY KEY CLUSTERED ([Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Currencys_Code]
    ON [dbo].[Currencys]([Code] ASC);


CREATE TABLE [dbo].[ExchangeRate] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Date]         DATETIME2 (7)   NOT NULL,
    [CurrencyCode] NVARCHAR (450)  NULL,
    [Rate]         DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_ExchangeRate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ExchangeRate_Currencys_CurrencyCode] FOREIGN KEY ([CurrencyCode]) REFERENCES [dbo].[Currencys] ([Code])
);


GO
CREATE NONCLUSTERED INDEX [IX_ExchangeRate_CurrencyCode]
    ON [dbo].[ExchangeRate]([CurrencyCode] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ExchangeRate_Date]
    ON [dbo].[ExchangeRate]([Date] ASC);

