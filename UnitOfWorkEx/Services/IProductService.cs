using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkEx.Database;

namespace UnitOfWorkEx.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductList();

        Product AddProduct(Product product);

        Product FindById(int productId);

        void UpdateProduct(Product product);

        Product RemoveProduct(int productId);
    }
}