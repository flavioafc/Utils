using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Entities;

namespace API.Data.Repository
{
    public class ShopRepository : IShopRepository
    {
        private readonly ShopContext _ctx;

        public ShopRepository(ShopContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _ctx.Products
                .OrderBy(p => p.Title).ToList();

        }

        public IEnumerable<Product> GetsProductsByCategory(string category)
        {
            return _ctx.Products
                .Where(c => c.Category == category)
                .ToList();
        }


        public bool Save()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
