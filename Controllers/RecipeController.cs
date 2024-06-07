using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple.Data;
using simple.Interfaces;
using simple.Models;

namespace simple.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : Controller
    {
        
        private readonly IRecipeRepo _recipe;
        

        public RecipeController(IRecipeRepo recipe)
        {
            this._recipe = recipe;
            
        }

        [HttpGet]
        public IActionResult GetRecipe()
        {
            var recipes = _recipe.GetAll();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Recipe))]
        [ProducesResponseType(400)]
        public IActionResult Get(int id) 
        {
            var recipe = _recipe.Get(id);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(recipe);
        }
        [HttpGet("search/")]
        public IActionResult Search(string name, string? ingredients){
            string ingredi = ingredients ?? "";
            try{
                var result = _recipe.GetByRecipeName(name, ingredi);
                if(result.Any()){
                    return Ok(result);
                }
                return NotFound();
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

    }
}
