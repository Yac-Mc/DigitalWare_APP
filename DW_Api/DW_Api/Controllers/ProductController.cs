using DW_Api.BusinessLogic;
using DW_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DW_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBL _productBL;

        public ProductController(IProductBL productBL)
        {
            _productBL = productBL;
        }

        [HttpGet]
        public async Task<ActionResult<GenericResponse<IEnumerable<Product>>>> Get()
        {
            return Ok(await _productBL.GetAllProducts());
        }

        [HttpGet("inventory")]
        public async Task<ActionResult<GenericResponse<IEnumerable<Inventory>>>> GetAllProductsInventory()
        {
            return Ok(await _productBL.GetAllProductsInventory());
        }

        [HttpPost("addProduct")]
        public async Task<ActionResult<GenericResponse<string>>> AddProduct(Inventory product)
        {
            return Ok(await _productBL.AddProduct(product));
        }

        [HttpPost("checkin")]
        public async Task<ActionResult<GenericResponse<string>>> Checkin(Checkin checkin)
        {
            return Ok(await _productBL.Checkin(checkin));
        }
    }
}
