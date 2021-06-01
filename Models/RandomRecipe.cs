using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kursovaya.Models
{
    public class ExtendedIngredient
    {
        public string Original { get; set; }
    }

    public class Recipe
    {
        public List<ExtendedIngredient> ExtendedIngredients { get; set; }
        public string Title { get; set; }
        public int ReadyInMinutes { get; set; }
        public int Servings { get; set; }
        public string Image { get; set; }
        public string Instructions { get; set; }
    }

    public class RandomRecipe
    {
        public List<Recipe> Recipes { get; set; }
    }
}
