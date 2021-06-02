using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kursovaya.Models
{
    public class ExtendedIngredients
    {
        public string Original { get; set; }
    }

    public class Steps
    {
        public int Number { get; set; }
        public string Step { get; set; }
    }

    public class AnalyzedInstruction
    {
        public string Name { get; set; }
        public List<Steps> Steps { get; set; }
    }

    public class Result
    {
        public string Title { get; set; }
        public List<ExtendedIngredients> ExtendedIngredients { get; set; }
        public int ReadyInMinutes { get; set; }
        public int Servings { get; set; }
        public string Image { get; set; }
        public List<AnalyzedInstruction> AnalyzedInstructions { get; set; }
    }

    public class RecipeByName
    {
        public List<Result> Results { get; set; }
        public string Title { get; internal set; }
        public string ReadyInMinutes { get; internal set; }
    }
}
