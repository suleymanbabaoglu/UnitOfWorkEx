using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkEx.Database;
using UnitOfWorkEx.UOW;

namespace UnitOfWorkEx.Services
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext context;
        private readonly IUnitOfWork unitOfWork;
        public ProductService(DatabaseContext context,IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
        }

        public Product AddProduct(Product product)
        {
            try
            {
                context.Products.AddAsync(product);
                return product;
            }
            catch (Exception)
            {
                unitOfWork.DisposeAsync();
                throw;
            }
        }

        public Product FindById(int productId)
        {
            try
            {
                var product = context.Products.Find(productId);
                return product;
            }
            catch (Exception)
            {
                unitOfWork.DisposeAsync();
                throw;
            }
        }

        public IEnumerable<Product> GetProductList()
        {
            try
            {
                var productList = context.Products.ToList();
                return productList;
            }
            catch (Exception)
            {
                unitOfWork.DisposeAsync();
                throw;
            }
        }

        public Product RemoveProduct(int productId)
        {
            try
            {
                var product = FindById(productId);
                context.Products.Remove(product);
                return product;
            }
            catch (Exception)
            {
                unitOfWork.DisposeAsync();
                throw;
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                context.Entry(product).State = EntityState.Modified;
            }
            catch (Exception)
            {
                unitOfWork.DisposeAsync();
                throw;
            }
        }
    }
}