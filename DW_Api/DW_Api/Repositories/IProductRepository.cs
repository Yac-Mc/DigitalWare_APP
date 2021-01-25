using DW_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DW_Api.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Inventory>> GetAllProductsInventory();
        Task AddProduct(Inventory product);
        Task Checkin(Checkin checkin);
    }
}
