using Microsoft.EntityFrameworkCore;
using simple.Interfaces;
using simple.Models;

namespace simple.Data
{
    public class DataContext : DbContext, IDataContext
    {   
        public DataContext(DbContextOptions option) : base(option) { }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Ingredient> Ingredients {  get; set; }
        public DbSet<Preparation> Preparation { get; set; }
        public int SaveChanges()
        {
            return base.SaveChanges();
        }
        
    }
}
