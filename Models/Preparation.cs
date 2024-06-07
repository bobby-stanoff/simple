namespace simple.Models
{
    public class Preparation
    {
        public int Id { get; set; }
        public string Prepare { get; set; }
        public Preparation()
        {
            
        }
        public Preparation(string prepare)
        {
            Prepare = prepare;
        }
    }
    
}
