using LoginAuthentication.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StoreController : ControllerBase
    {
        private static readonly string[] _brands = new[] { "Adidas", "Nike", "Puma" };
        private static readonly string[] _model = new[] { "Sport", "Casual", "Street" };

        [Authorize("admin")]
        [HttpGet("all")]
        public IActionResult GetProducts()
        {
            return Ok(MockProducts());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProductById(int id)
        {
            return Ok(GetProduct(id));
        }


        private IEnumerable<Product> MockProducts()
        {
            return Enumerable.Range(1, 5).Select(index => new Product
            {
                Id = index,
                Amount = 5,
                Available = true,
                Brand = _brands[Random.Shared.Next(_brands.Length)],
                Model = _model[Random.Shared.Next(_model.Length)],
                Size = 41,
                Price = 250
            }).ToArray();

        }

        private Product GetProduct(int id)
        {
            var product = MockProducts().Where(p => p.Id == id).FirstOrDefault();
            return product;
        }
    }
}
