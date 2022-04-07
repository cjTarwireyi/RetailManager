CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProductName] NCHAR(100) NOT NULL, 
    [Description] NCHAR(10) NOT NULL, 
    [ReatailPrice] MONEY NOT NULL,
    [CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [LastModifiedDate] DATETIME2 NOT NULL DEFAULT getutcdate(),    
)
