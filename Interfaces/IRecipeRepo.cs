using simple.Models;

namespace simple.Interfaces
{
    public interface IRecipeRepo
    {
        public IEnumerable<Recipe> GetAll();
        public Recipe Get(int id);
        public IEnumerable<Recipe> GetByRecipeName(string name, string? ingredients);
    }
}
