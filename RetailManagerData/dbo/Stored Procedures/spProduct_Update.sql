CREATE PROCEDURE [dbo].[spProduct_Update]
	@ProductId int = 0,
	@PurchasedQuantity int
AS
begin
	set nocount on;
	update dbo.Product 
	set QuantityInStock =(select QuantityInStock from dbo.Product where Id= @ProductId) - @PurchasedQuantity
	where Id = @ProductId
end
