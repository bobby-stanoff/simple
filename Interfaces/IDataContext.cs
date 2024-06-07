using Microsoft.EntityFrameworkCore;
using simple.Models;

namespace simple.Interfaces
{
    public interface IDataContext 
    {
        
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Preparation> Preparation { get; set; }

    }
}
