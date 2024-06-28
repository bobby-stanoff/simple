using Microsoft.AspNetCore.Mvc;
using simple.Dto;
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
        private RecipeDto RecipeMap( Recipe x){
            RecipeDto RecipeObj = new RecipeDto(){
                SourceName = x.SourceName,
                SourceLink = x.SourceLink,
                Id = x.Id,
                Name = x.Name,
                RecipeLink = x.RecipeLink,
                Ingredients = x.Ingredients.Select(i => $"{i.Quantity} {i.Name}").ToList(),
                Preparation = x.Preparation.Select(i => $"{i.Prepare}").ToList(),
                Description = x.Description,
                Image = x.Image,
                Author = x.Author
            };
            return RecipeObj;
        }

        [HttpGet]
        public IActionResult GetRecipe()
        {
            var recipes = _recipe.GetAll();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!recipes.Any()){
                return NotFound();
            }
            return Ok(recipes);
        }
		[HttpPost("postrecipe/")]
        public IActionResult AddRecipe([FromBody] RecipeDto req)
        {
            var newrecipe = new Recipe(
                req.SourceName,
                req.Name,
                req.RecipeLink,
                req.Ingredients,
                req.SourceLink,
                req.Image,
                req.Author,
                req.Preparation,
                req.Description
            );
            if(req == null){
                return BadRequest(ModelState);
            }
			try{
                var re = _recipe.GetByRecipeName(newrecipe.Name);

                if(re.Any()){
                    ModelState.AddModelError("","already exist");
                    return StatusCode(422, ModelState);
                }
                else _recipe.Add(newrecipe);
			}
            catch(Exception e){
                throw;
            }
			return Ok("create success");	
		}
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Recipe))]
        [ProducesResponseType(400)]
        public IActionResult GetDetailsRecipe(int id) 
        {
            var recipe = _recipe.Get(id);
            if(recipe == null){
                return NotFound();
            }
            var returnObject = RecipeMap(recipe);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }    
            return Ok(returnObject);
        }
        [HttpGet("search/")]
        public IActionResult Search(string name, string? ingredients){
            string ingredi = ingredients ?? "";

            try{
                var result = _recipe.GetByRecipeName(name, ingredi);
                List<RecipeDto> returnObject = new List<RecipeDto>();
                
                if(result.Any()){
                    foreach(var ri in result){
                    returnObject.Add(RecipeMap(ri));
                    }
                    return Ok(returnObject);
                }
                return Ok(returnObject);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

    }
}
