using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApiDbContext _apiDbContext;
        public ProductController(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        //GET api/Product
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _apiDbContext.Products.ToListAsync();
        }

        //muestra registro por id
        //GET api/Product/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (id != null && id > 0)
            {
                try
                {
                    var product = _apiDbContext.Products.FirstOrDefaultAsync(e => e.Id == id);
                    if (product != null) { return Ok(await product); }
                    else { return BadRequest(); }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest();
        }

        //elimina registro
        //DELETE api/Product/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null && id > 0)
            {
                try
                {
                    var product = _apiDbContext.Products.FirstOrDefault(e => e.Id == id);
                    if (product != null)
                    {
                        _apiDbContext.Products.Remove(product);
                        await _apiDbContext.SaveChangesAsync();
                        return Ok();
                    }
                    else { return BadRequest(); }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest();
        }

        //agrega nuevo registro
        // POST api/Product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (product != null)
            {
                try
                {
                    _apiDbContext.Products.Add(product);
                    await _apiDbContext.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest();
        }

        //actualiza registro
        //PATCH api/Product/1
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int? id, [FromBody] Product product)
        {
            if (id > 0 && id != null && product != null)
            {
                try
                {
                    _apiDbContext.Products.Update(product);
                    await _apiDbContext.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest();
        }
    }
}
