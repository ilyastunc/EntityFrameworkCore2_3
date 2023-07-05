using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore2_3.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products {get;}
        void CreateProduct(Product product);
        Product GetProductById(int productId);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}