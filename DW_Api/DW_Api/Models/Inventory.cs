using System;

namespace DW_Api.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Description { get; set; }
        public string Maker { get; set; }
    }
}
