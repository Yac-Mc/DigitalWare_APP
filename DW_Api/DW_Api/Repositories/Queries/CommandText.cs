using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DW_Api.Repositories.Queries
{
    public class CommandText : ICommandText
    {
        public string GetAllProducts => "SELECT * FROM dbo.Product";
        public string GetAllProductsInventory => "SELECT I.*, P.Name AS ProductName FROM [dbo].[Inventory] I INNER JOIN  dbo.Product P ON P.Id = I.ProductId";
        public string InsertProduct => "INSERT INTO dbo.[Product] ([Name], [Description], [Maker]) VALUES (@Name, @Description, @Maker)";
        public string GetLastProduct => "SELECT MAX(Id) Id FROM dbo.Product";
        public string InsertInventory => "INSERT INTO dbo.[Inventory] (ProductId, UnitPrice, Quantity, PurchaseDate) VALUES(@ProductId, @UnitPrice, @Quantity, GETDATE())";
        public string InsertClient => "INSERT INTO dbo.[Client] (IdentificationNumber, DocumentType, FirstName, SecondName, Surname, SecondSurname, BirthDate) VALUES(@IdentificationNumber, @DocumentType, @FirstName, @SecondName, @Surname, @SecondSurname, @BirthDate)";
        public string GetClientId => "SELECT Id FROM dbo.Client WHERE IdentificationNumber = @IdentificationNumber";
        public string InsertSales => "INSERT INTO dbo.[Sales] (ProductId, ClientId, SaleDate, Quantity) VALUES(@ProductId, @ClientId, GETDATE(), @Quantity)";
        public string UpateInventory => "UPDATE [dbo].[Inventory] SET Quantity = (Quantity - @Quantity) Where ProductId = @ProductId";
        public string GetProductId => "SELECT Id FROM dbo.Product WHERE [Name] = @ProductName";
    }
}
