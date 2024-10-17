using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoEstacio.Services;

namespace ProjetoEstacio.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
       private readonly ProductService _productService;

       public ProductController(ProductService productService)
       {
           _productService = productService;
       }

       [HttpGet("get-all-products")]
       public async Task<IActionResult> GetAllProducts()
       {
           var result = await _productService.GetAllProductsAsync();
           if (result == null)
           {
               return NotFound("Nenhum produto encontrado");
           }
           
           return Ok(result);
       }
        
    }
}