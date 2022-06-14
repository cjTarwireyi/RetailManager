CREATE PROCEDURE [dbo].[spProductGetAll]
AS
begin
set nocount on
	SELECT Id, ProductName, [Description], RetailPrice, QuantityInStock, IsTaxable from [dbo].[Product]
	order by ProductName
end
