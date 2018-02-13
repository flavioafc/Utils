using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace API.Data
{
    public class ShopSeeder
    {
        private readonly ShopContext _shopContext;
        public readonly IHostingEnvironment _hosting;

        public ShopSeeder(ShopContext ctx, IHostingEnvironment hosting)
        {
            _shopContext = ctx;
            _hosting = hosting;
        }



        public void Seed()
        {
            _shopContext.Database.EnsureCreated();

            if (!_shopContext.Products.Any())
            {

                //need to create data
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filepath);

                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _shopContext.Products.AddRange(products);

                var order = new Order()
                {
                    OrderDate = DateTime.Now,
                    OrderNumber = "1234",

                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }

                    }
                };

                _shopContext.Add(order);
                _shopContext.SaveChanges();
            }
        }
    }
}
