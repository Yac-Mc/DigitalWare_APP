using DW_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DW_Api.BusinessLogic
{
    public interface IProductBL
    {
        Task<GenericResponse<IEnumerable<Product>>> GetAllProducts();
        Task<GenericResponse<IEnumerable<Inventory>>> GetAllProductsInventory();
        Task<GenericResponse<string>> AddProduct(Inventory product);
        Task<GenericResponse<string>> Checkin(Checkin checkin);
    }
}
