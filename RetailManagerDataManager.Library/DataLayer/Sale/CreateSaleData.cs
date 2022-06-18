using RetailManagerDataManager.Library.DataLayer.Product;
using RetailManagerDataManager.Library.Internal.DataAccess;
using RetailManagerDataManager.Library.Models;
using RetailManagerDesktopUI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RetailManagerDataManager.Library.DataLayer.Sale
{
    public class CreateSaleData
    {
        public void SaveSale(SaleModel saleInfo, string cashierId)
        {
            GetSingleProduct productDbTable = new GetSingleProduct();
            var vat = ConfigHelperExt.GetTaxRate();
            var saleDetails = new List<SaleDetailDbModel>();
            foreach (var item in saleInfo.SaleDetails)
            {
                var saleDetail = new SaleDetailDbModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                };

                var productInfo = productDbTable.GetProductById(item.ProductId);
                if(productInfo == null)
                {
                    throw new Exception($"The product Id of {item.ProductId} could not be found in the database");
                }

                saleDetail.PurchasePrice = (productInfo.RetailPrice * saleDetail.Quantity);
                if (productInfo.IsTaxable)
                {
                    saleDetail.Tax = (saleDetail.PurchasePrice * vat);
                }
                saleDetails.Add(saleDetail);
            }
            SaleDbModel sale = new SaleDbModel 
            {
                SubTotal = saleDetails.Sum(x => x.PurchasePrice),
                Tax = saleDetails.Sum(x => x.Tax),
                CashierId = cashierId
            };

            sale.Total = sale.SubTotal + sale.Tax;
            using (SqlDataAccess sql = new SqlDataAccess())
            {
                try
                {
                    sql.StartTransaction("DefaultConnection");

                    sql.SaveDataInTransaction("dbo.spSale_Insert", sale);

                    var saleId = sql.LoadDataInTransaction<int, dynamic>("dbo.spSale_GetByExpression", new { sale.CashierId, sale.SaleDate }).FirstOrDefault();
                    foreach (var item in saleDetails)
                    {
                        item.SaleId = saleId;
                        sql.SaveDataInTransaction("dbo.spSaleDetail_Insert", item);
                        sql.SaveDataInTransaction("dbo.spProduct_Update", new { item.ProductId, PurchasedQuantity = item.Quantity });
                    }
                    sql.CommitTransaction();
                }
                catch
                {
                   sql.RollBackTransaction();
                    throw;
                }
            }
        }
    }
}
