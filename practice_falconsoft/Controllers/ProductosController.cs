using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practice_falconsoft.Entities;
using practice_falconsoft.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_falconsoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductosController : Controller
    {
        private readonly IProductoRepo _productoRepo;

        public ProductosController(IProductoRepo productoRepo)
        {
            _productoRepo = productoRepo;
        }

        [HttpGet("{id}")]
        public ActionResult GetProducto(Guid id)
        {
            var producto = _productoRepo.getProducto(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [HttpPut("UpdateProducto")]
        public IActionResult UpdateProducto(Guid id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            if (!_productoRepo.ProductExists(id))
            {
                return NotFound();
            }

            try
            {
                _productoRepo.updateProducto(producto);
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_productoRepo.ProductExists(id))
                    return NotFound(); 
                else 
                    throw; 
            }
        }

        
    }
}
