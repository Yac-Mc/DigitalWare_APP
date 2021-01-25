using Dapper;
using DW_Api.Models;
using DW_Api.Repositories.Queries;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DW_Api.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly ICommandText _commandText;

        public ProductRepository(IConfiguration configuration, ICommandText commandText) : base(configuration)
        {
            _commandText = commandText;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await WithConnection(async conn =>
            {
                var result = await conn.QueryAsync<Product>(_commandText.GetAllProducts);
                return result;
            });
        }

        public async Task<IEnumerable<Inventory>> GetAllProductsInventory()
        {
            return await WithConnection(async conn =>
            {
                var result = await conn.QueryAsync<Inventory>(_commandText.GetAllProductsInventory);
                return result;
            });
        }

        public async Task AddProduct(Inventory product)
        {
            await WithConnection(async conn =>
            {
                product.ProductId = await conn.QueryFirstOrDefaultAsync<int>(_commandText.GetProductId, new { Name = product.ProductName });
                if (product.ProductId == 0)
                {
                    await conn.ExecuteAsync(_commandText.InsertProduct, new { Name = product.ProductName, Description = product.Description, Maker = product.Maker });
                    product.ProductId = await conn.QueryFirstOrDefaultAsync<int>(_commandText.GetLastProduct);
                    await conn.ExecuteAsync(_commandText.InsertInventory, new { ProductId = product.ProductId, UnitPrice = product.UnitPrice, Quantity = product.Quantity });
                }
            });
        }

        public async Task Checkin(Checkin checkin)
        {
            await WithConnection(async conn =>
            {
                checkin.ClientId = await conn.QueryFirstOrDefaultAsync<int>(_commandText.GetClientId, new { IdentificationNumber = checkin.IdentificationNumber });
                if (checkin.ClientId == 0)
                {
                    await conn.ExecuteAsync(_commandText.InsertClient, new { IdentificationNumber = checkin.IdentificationNumber, DocumentType = checkin.DocumentType, FirstName = checkin.FirstName, SecondName = checkin.SecondName, Surname = checkin.Surname, SecondSurname = checkin.SecondSurname, BirthDate = checkin.BirthDate });
                    checkin.ClientId = await conn.QueryFirstOrDefaultAsync<int>(_commandText.GetClientId, new { IdentificationNumber = checkin.IdentificationNumber });
                }
                await conn.ExecuteAsync(_commandText.InsertSales, new { ProductId = checkin.ProductId, ClientId = checkin.ClientId, Quantity = checkin.Quantity });
                await conn.ExecuteAsync(_commandText.UpateInventory, new { ProductId = checkin.ProductId, Quantity = checkin.Quantity });
            });
        }
    }
}
