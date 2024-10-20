using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoEstacio.DTOs;
using ProjetoEstacio.Model;
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

       [HttpGet("{id}")]
       public async Task<IActionResult> GetProductId(Guid id)
       {
           var result = await _productService.GetProductByIdAsync(id);
           if (result == null)
           {
               return NotFound("Nenhum produto encontrado");
           }
           
           return Ok(result);
       }

       [HttpPost("create-product")]
       public async Task<IActionResult> CreateProduct([FromBody] ProductDTO product)
       {
           try
           {
               if (product == null)
               {
                   BadRequest("Os Dados deve ser informado");
               }
                await _productService.AddProductAsync(product);
               return  CreatedAtAction(nameof(GetProductId), new { id = product.Id }, "Produto criado com sucesso");
           }
           catch (Exception e)
           {
               Console.WriteLine(e);
               throw new Exception("ruim");
           }
       }
    }
}