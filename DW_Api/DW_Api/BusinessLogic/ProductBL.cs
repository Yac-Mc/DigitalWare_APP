using DW_Api.Models;
using DW_Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DW_Api.BusinessLogic
{
    public class ProductBL : IProductBL
    {
        private readonly IProductRepository _productRepository;

        public ProductBL(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GenericResponse<IEnumerable<Product>>> GetAllProducts()
        {
            GenericResponse<IEnumerable<Product>> resultDB = new GenericResponse<IEnumerable<Product>>()
            {
                Result = await _productRepository.GetAllProducts()
            };
            return resultDB;
        }

        public async Task<GenericResponse<IEnumerable<Inventory>>> GetAllProductsInventory()
        {
            GenericResponse<IEnumerable<Inventory>> resultDB = new GenericResponse<IEnumerable<Inventory>>()
            {
                Result = await _productRepository.GetAllProductsInventory()
            };
            return resultDB;
        }

        public async Task<GenericResponse<string>> AddProduct(Inventory product)
        {
            await _productRepository.AddProduct(product);
            GenericResponse<string> response = new GenericResponse<string>();
            return response;
        }

        public async Task<GenericResponse<string>> Checkin(Checkin checkin)
        {
            await _productRepository.Checkin(checkin);
            GenericResponse<string> response = new GenericResponse<string>();
            return response;
        }
    }
}
