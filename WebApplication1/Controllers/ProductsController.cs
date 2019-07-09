using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public static List<Products> produkti = new List<Products>
       {
            new Products { Id = 1, Ime = "Marko", Prezime = "Tolja", Pozicija = "Direktor" },
            new Products { Id = 2, Ime = "Tomislav", Prezime = "Pribanić", Pozicija = "Upravitelj stroja" },
            new Products { Id = 3, Ime = "Zdravko", Prezime = "Grba", Pozicija = "Varioc" },
            new Products { Id = 4, Ime = "Ivica", Prezime = "Klasnić", Pozicija = "Spremač" },
            new Products { Id = 5, Ime = "Zdenko", Prezime = "Jevrić", Pozicija = "Varioc" }

       };

        public IEnumerable<Products> GetAllProducts()
        {
            return produkti;
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var product = produkti.FirstOrDefault((p) => p.Id == id);

            if (product == null)
            {

                return StatusCode(404, "Product not found!");

            }

            return Ok(product);
        }

        [Route("")]
        [HttpPost]
        public IActionResult PostProduct([FromForm] Products product) // fromform - ako koristiš form u html-u, a frombody ako koristiš ajax post metodu
        {
            produkti.Add(product);

            return Ok(product);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult PutProduct(int id, [FromForm] Products model)
        {

            var product = produkti.FirstOrDefault((p) => p.Id == id);

            if (product != null)
            {
                product.Ime = model.Ime;
                product.Prezime = model.Prezime;
                product.Pozicija = model.Pozicija;

                return Ok(product);
            }
            return StatusCode(404, "Product not found!");
        }
        
        
    }
}