using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kursovaya.Models
{
    public class ExtendedIngredient1
    {
        public string original { get; set; }
    }

    public class Step1
    {
        public int number { get; set; }
        public string step { get; set; }
    }

    public class AnalyzedInstruction1
    {
        public string name { get; set; }
        public List<Step1> steps { get; set; }
    }

    public class Result1
    {
        public List<ExtendedIngredient1> extendedIngredients { get; set; }
        public string title { get; set; }
        public int readyInMinutes { get; set; }
        public string image { get; set; }
        public List<AnalyzedInstruction1> analyzedInstructions { get; set; }
    }

    public class RandomCocktail
    {
        public List<Result1> results { get; set; }
    }

   
}
