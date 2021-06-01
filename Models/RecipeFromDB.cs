using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kursovaya.Models
{
    public class RecipeFromDB
    {
        public string Title { get; set; }
        public string ReadyInMinutes { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }

    }
}
