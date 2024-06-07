
using Microsoft.AspNetCore.Mvc;

namespace simple
{
    public class yo:Controller
    {
        private string a;
        
        public yo(string b)
        {
            this.a = b;
        }
        public string R()
        {
            return this.a;
        }
    }
}
