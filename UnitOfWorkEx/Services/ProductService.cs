﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitOfWorkEx.Database;

namespace UnitOfWorkEx.Services
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext context;

        public ProductService(DatabaseContext context)
        {
            this.context = context;
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
                throw;
            }
        }
    }
}