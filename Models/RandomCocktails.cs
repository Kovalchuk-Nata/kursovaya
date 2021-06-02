using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kursovaya.Models
{
    public class ExtendedIngredientt
    {
        public string Original { get; set; }
    }

    public class Recipee
    {
        public List<ExtendedIngredientt> ExtendedIngredients { get; set; }
        public string Title { get; set; }
        public int ReadyInMinutes { get; set; }
        public int Servings { get; set; }
        public string Image { get; set; }
        public string Instructions { get; set; }
    }

    public class RandomCocktails
    {
        public List<Recipe> Recipes { get; set; }
    }
}
