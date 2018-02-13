using System.Collections.Generic;
using API.Data.Entities;

namespace API.Data.Repository
{
    public interface IShopRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetsProductsByCategory(string category);
        bool Save();
    }
}