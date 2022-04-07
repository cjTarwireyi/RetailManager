CREATE TABLE [dbo].[SaleDetail]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SaleId] INT NOT NULL, 
    [productId] INT NOT NULL, 
    [Quantity] MONEY NOT NULL DEFAULT 1,
    [PurchasePrice] MONEY NOT NULL, 
    [Tax] MONEY NOT NULL DEFAULT 0    
)
