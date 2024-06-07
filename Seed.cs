using simple.Data;
using simple.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace simple
{
    
    public class Root
    {
        
        public string source_name { get; set; }
        public string name { get; set; }
        public string recipe_link { get; set; }
        public List<string> ingredients { get; set; }
        public string source_link { get; set; }
        public string image { get; set; }
        public string author { get; set; }
        public List<string> preparation { get; set; }
        public string desc { get; set; }
    }

    public class Seed
    {
        private readonly DataContext _db;

        public Seed(DataContext db)
        {
            this._db = db;
        }
        public void LoadJson()
        {
            if (this._db.Recipe.Count() == 0)
            {
                string rawData = System.IO.File.ReadAllText("./Data/epicuriousrecipes.json");
                var RawRecipes = JsonSerializer.Deserialize<List<Root>>(rawData);
                var Recipes = new List<Recipe>();
                foreach (var rrecipe in RawRecipes)
                {   
                    Recipe item = new Recipe(rrecipe.source_name, rrecipe.name, rrecipe.recipe_link, rrecipe.ingredients, rrecipe.source_link, rrecipe.image, rrecipe.author,rrecipe.preparation,rrecipe.desc);
                    Recipes.Add(item);
                }
                _db.AddRange(Recipes);
                _db.SaveChanges();

            }
        }
      
    }
}
