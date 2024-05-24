using Microsoft.AspNetCore.Mvc;
using CRUDCoreAPIMVC.Model;

namespace CRUDCoreAPIMVC.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private List<Product> products = new List<Product>()
        {
            new Product(){Id = 1, Name ="Laptop", Price = 1000},
            new Product(){Id = 2, Name ="Desktop", Price = 2000}
        };

        // GET requests are used to request data from a specified resource.
        // They should not change the state of the server.
        // GET: api/v1.0/Product
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            //Fetch all the Products
            return Ok(products);
        }

        // GET: api/v1.0//Product/1
        [HttpGet("{Id}")]
        public async Task<ActionResult<Product>> GetProductById(int Id)
        {
            var product = products.FirstOrDefault(prd => prd.Id == Id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST requests are used to send data to the server to create a new resource.
        // The data is included in the body of the request.
        // POST: api/v1.0/Items
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            //Add the Product to the Database
            product.Id = 3;
            products.Add(product);

            return CreatedAtAction("GetProductById", new { Id = product.Id }, product);
        }

        // PUT requests are used to send data to a specific resource for update.
        // Unlike POST, PUT is idempotent, meaning multiple identical requests should have the same effect as a single one.
        // PUT: api/v1.0/Product/1
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateProduct(int Id, Product product)
        {
            if (Id != product.Id)
            {
                return BadRequest();
            }

            var existingProduct = products.FirstOrDefault(prd => prd.Id == Id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            //Update the Product Name and Price
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            //Update the Data into the database

            return Ok();
        }

        // DELETE requests are used to remove a specific resource identified by a URI.
        // DELETE: api/v1.0/Product/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var product = products.FirstOrDefault(prd => prd.Id == Id);
            if (product == null)
            {
                return NotFound();
            }

            //Remove the Product
            products.Remove(product);

            return Ok();
        }

        // PATCH requests are used for making partial updates to an existing resource.
        // This method allows sending a partial list of changes to the resource, reducing bandwidth and processing time.
        // PATCH: api/v1.0/Product/5
        [HttpPatch("{Id}")]
        public async Task<IActionResult> PatchProduct(int Id, Product product)
        {
            var existingProduct = products.FirstOrDefault(prd => prd.Id == Id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            //Update only the require Properties, not all
            existingProduct.Name = product.Name;

            //Update the data into the database

            return NoContent();
        }

        // Ensure the HEAD method shares the same routing as the GET method for a resource.
        // HEAD: api/v1.0/Product/5
        [HttpHead("{Id}")]
        public ActionResult<Product> GetProductHead(int Id)
        {
            var product = products.FirstOrDefault(prd => prd.Id == Id);
            if (product == null)
            {
                return NotFound();
            }

            return NoContent();
            // Or Ok() with no body content
        }

        // For OPTIONS requests, it's common to return an empty body with a 200 OK status code, with the Allow header specifying the allowed methods.
        // OPTIONS: api/v1.0/Product
        [HttpOptions]
        public IActionResult Options()
        {
            Response.Headers.Add("Allow", "GET,POST,PUT,PATCH,DELETE,HEAD,OPTIONS");
            return Ok();
        }
    }
}