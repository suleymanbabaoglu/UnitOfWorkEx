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
        private readonly IUnitOfWork unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Product AddProduct(Product product)
        {
            try
            {
                unitOfWork.Context.Products.AddAsync(product);
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
                var product = unitOfWork.Context.Products.Find(productId);
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
                var productList = unitOfWork.Context.Products.ToList();
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
                unitOfWork.Context.Products.Remove(product);
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
                unitOfWork.Context.Entry(product).State = EntityState.Modified;
            }
            catch (Exception)
            {
                unitOfWork.DisposeAsync();
                throw;
            }
        }
    }
}