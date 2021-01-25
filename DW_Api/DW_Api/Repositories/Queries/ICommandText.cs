using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DW_Api.Repositories.Queries
{
    public interface ICommandText
    {
        string GetAllProducts { get; }
        string GetAllProductsInventory { get; }
        string InsertProduct { get; }
        string GetLastProduct { get; }
        string InsertInventory { get; }
        string InsertClient { get; }
        string GetClientId { get; }
        string InsertSales { get; }
        string UpateInventory { get; }
        string GetProductId { get; }
    }
}
