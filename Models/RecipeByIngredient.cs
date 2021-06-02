using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kursovaya.Models
{
    public class extendedIngredient
    {
        public string Original { get; set; }
    }

    public class Step
    {
        public int Number { get; set; }
        public string Steps { get; set; }
    }

    public class AnalyzedInstructions
    {
        public List<Step> Steps { get; set; }
    }

    public class Results
    {
        public List<extendedIngredient> ExtendedIngredients { get; set; }
        public string Title { get; set; }
        public int ReadyInMinutes { get; set; }
        public int Servings { get; set; }
        public string Image { get; set; }
        public List<AnalyzedInstructions> AnalyzedInstructions { get; set; }
    }


    public class RecipeByIngredient
    {
        public List<Result> Results { get; set; }
    }
    
}
