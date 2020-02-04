using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkEx.Database;
using UnitOfWorkEx.Services;
using UnitOfWorkEx.UOW;

namespace UnitOfWorkEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductService productService;

        public ProductController(IUnitOfWork unitOfWork, IProductService productService)
        {
            this.productService = productService;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var productList = productService.GetProductList();
            return Ok(productList);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProduct(int id)
        {
            var product = productService.FindById(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var pro = new Product()
            {
                ProductCategory = "a",
                ProductName = " as",
                ProductPrice = 12
            };
            productService.AddProduct(product);

            unitOfWork.SaveAsync();
            return Ok(product);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct(Product product)
        {
            productService.UpdateProduct(product);
            unitOfWork.SaveAsync();
            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoveProduct(int Id)
        {
            var product = productService.FindById(Id);
            productService.RemoveProduct(Id);
            unitOfWork.SaveAsync();
            return Ok(product);
        }
    }
}