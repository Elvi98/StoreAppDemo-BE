using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Data;
using StoreApp.Entities;
using StoreApp.Web.Models;

namespace StoreApp.Web.Controllers
{
    [Route("api/[controller]")] //localhost:8080/api/Categories
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DbContextStoreApp _context;

        public CategoriesController(DbContextStoreApp context)
        {
            _context = context;
        }


        // GET: api/Categories
        [HttpGet]
        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            var categoryList = await _context.Categories.ToListAsync();

            return categoryList.Select(c => new CategoryModel
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description,
                Condition = c.Condition
            });
        }

        // GET: api/Categories/GetCategoryById/5
        //[HttpGet("{id}")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(new CategoryModel
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description
            });
        }

        // PUT: api/Categories/PutCategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        [HttpPut("[action]")]
        public async Task<IActionResult> PutCategory([FromBody] UpdateCategoryModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.CategoryId <= 0)
                return BadRequest();

            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == model.CategoryId);

            if (category == null)
                return NotFound();

            category.Name = model.Name;
            category.Description = model.Description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] CreateCategoryModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Category category = new Category
            {
                Name = model.Name,
                Description = model.Description,
                Condition = true
            };

            _context.Categories.Add(category);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        //PUT: api/Categories/UpdateCondition/{id}/{condition}
        [HttpPut("[action]/{id}/{condition}")]
        public async Task<IActionResult> UpdateCondition([FromRoute] int id, [FromRoute] bool condition)
        {
            if (id <= 0)
                return BadRequest();

            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);

            if (category == null)
                return NotFound();

            category.Condition = condition;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}