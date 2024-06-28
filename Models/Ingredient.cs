using System.Text.RegularExpressions;

namespace simple.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Quantity { get; set; }
        public Ingredient()
        {
            
        }
        public Ingredient(string name)
        {
            string pattern = @"(\d+)(?:\/\d+)?\s*(.*)";
            Match match = Regex.Match(name, pattern);
            if (match.Success)
            {
                Quantity = match.Groups[1].Value;
                Name = match.Groups[2].Value;
            }
            else
            {
                Quantity = ""; 
                Name = name;
            }
        }
    }
}
