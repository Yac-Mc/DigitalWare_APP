using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DW_Api.Models
{
    public class Checkin
    {
        public string IdentificationNumber { get; set; }
        public string DocumentType { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        public DateTime BirthDate { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public int Quantity { get; set; }
    }
}
