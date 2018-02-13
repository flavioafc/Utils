using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Data.Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ShopController : Controller
    {
        private readonly IShopRepository _repo;

        public ShopController(IShopRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Shop()
        {
            var results = _repo.GetAllProducts();

            return Ok(results.ToList());
        }
    }
}
