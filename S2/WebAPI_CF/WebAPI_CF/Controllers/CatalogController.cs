using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_CF.Model;

namespace WebAPI_CF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private MyDbContext _context;
        public CatalogController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var catalogList = _context.Catalogs.ToList();
            return Ok(catalogList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var catalog = _context.Catalogs.SingleOrDefault(c => c.CataID == id);
            if(catalog != null)
            {
                return Ok(catalog);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Creat(CatalogModel model)
        {
            try
            {
                var catalog = new Catalog
                {
                    Cataname = model.Cataname
                };

                _context.Add(catalog);
                _context.SaveChanges();
                return Ok(catalog);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CatalogModel model)
        {
            var catalog = _context.Catalogs.SingleOrDefault(c => c.CataID == id);
            if (catalog != null)
            {
                catalog.Cataname = model.Cataname;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var catalog = _context.Catalogs.SingleOrDefault(c => c.CataID == id);
                if (catalog == null)
                {
                    return NotFound();
                }
                //delete
                _context.Catalogs.Remove(catalog);
                _context.SaveChanges();
                return Ok(catalog);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
