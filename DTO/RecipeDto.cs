using simple.Models;

namespace simple.Dto
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string SourceName { get; set; }
        public string Name { get; set; }
        public string RecipeLink { get; set; }
        public List<string> Ingredients { get; set; }
        public string SourceLink { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public List<string> Preparation { get; set; }
        public string Description { get; set; }

    }
}