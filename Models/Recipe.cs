using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace simple.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [AllowNull]
        public string SourceName { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public string RecipeLink { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string SourceLink { get; set; }
        [AllowNull]
        public string Image { get; set; }
        [MaxLength(100)]
        [AllowNull]
        public string Author { get; set; }
        public List<Preparation> Preparation { get; set; }
        public string Description { get; set; }
        public Recipe()
        {
            
        }
        public Recipe(string sourcename, string name, string recipelink, List<string> ingredients, string sourcelink, string image, string author, List<string> preparations, string description)
        {
            Ingredients = new List<Ingredient>();
            Preparation = new List<Preparation>();
            SourceName = sourcename;
            Name = name;
            RecipeLink = recipelink;
            Description = description;
            foreach (string s in ingredients)
            {
                Ingredient ing = new Ingredient(s);
                Ingredients.Add(ing);
            }
            SourceLink = sourcelink;
            Image = image;
            Author = author;
            foreach(string s in preparations)
            {
                Preparation pre = new Preparation(s); 
                Preparation.Add(pre);
            }
            Description = description;

        }
    }
    
    
}
