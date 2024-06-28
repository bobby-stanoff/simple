using Microsoft.EntityFrameworkCore;
using simple.Data;
using simple.Interfaces;
using simple.Models;

namespace simple.Respository
{
    public class RecipeRepository : IRecipeRepo

    {
        private readonly IDataContext _db;
         
        public RecipeRepository(IDataContext db)
        {
            this._db = db;
        }
        public IEnumerable<Recipe> GetAll()
        {
            //var recipe = _db.Recipe.OrderBy(name =>  name).ToList();
            var recipe = _db.Recipe.OrderBy(p => p.Name).Take(30).ToList();
            return recipe;
        }
        public Recipe Get(int recipeid) => _db.Recipe.Include(r => r.Ingredients).Include(r => r.Preparation).FirstOrDefault(x => x.Id == recipeid);
        public void Add(Recipe recipe){
            _db.Recipe.Add(recipe);
            _db.SaveChanges();
        }
        public IEnumerable<Recipe> GetByRecipeName(string name, string? ingredients)
        {
            IEnumerable<Recipe> res2;
            var res = _db.Recipe.Include(r => r.Ingredients).Include(r => r.Preparation).ToList();
            if (ingredients == "" || ingredients == null){
                res2 = res.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
                return res2;
            }
            var res1 = res.Where(y => {
                if (y.Ingredients.Any(i =>
                {
                    bool v = i.Name.Contains(ingredients);
                    return v;
                })){
                    return true;
                }
                return false ;
            } ).ToList();
            
            return res1;
        } 
    }
}
