//using Amazon.DynamoDBv2;
//using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime.Internal.Transform;
using kursovaya.Clients;
using kursovaya.Extentions;
using kursovaya.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace kursovaya.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomRecipeController : ControllerBase
    {


        private readonly ILogger<RandomRecipeController> _logger;
        private readonly RecipeClients _recipeClient;
        private readonly IDynamoDBClient _dynamoDBClient;

        public RandomRecipeController(ILogger<RandomRecipeController> logger, RecipeClients recipeClients, IDynamoDBClient dynamoDBClient)                    
        {
            _logger = logger;
            _recipeClient = recipeClients;
            _dynamoDBClient = dynamoDBClient;
        }
        

         
        [HttpGet("Random")]
        public async Task<RandomRecipe> GetRandomRecipe()
        {
            var recipe = await _recipeClient.GetRandomRecipe();

            return recipe;
        }

        [HttpGet("ByName")]
        public async Task<RecipeByName> GetRecipeByName([FromQuery] string title)
        {
            var recipebyname = await _recipeClient.GetRecipeByName(title);
            return recipebyname;
        }

        [HttpGet("ByIngredient")]
        public async Task<RecipeByIngredient> GetRecipeByIngredient([FromQuery] string ingredient)
        {
            var recipebyingr = await _recipeClient.GetRecipeByIngredient(ingredient);
            return recipebyingr;
        }

        [HttpGet("GetRecipeFromDB")]
        public async Task<RecipeFromDB> GetRecipeFromDB([FromQuery] string title)
        {
            var result = await _dynamoDBClient.GetRecipeByNameFromDB(title);
            if (result == null)
                return null;
            var recipeFromDB = new RecipeFromDB
            {
                Title = result.Title,
                ReadyInMinutes = result.ReadyInMinutes,
                Ingredients = result.Ingredients,
                Instructions = result.Instructions
            };
            return result;
        }

        [HttpGet("RandomCocktail")]
        public async Task<RandomCocktail> GetRandomCocktail([FromQuery] int offset)
        {
            var recipe = await _recipeClient.GetRandomCocktail(offset);

            return recipe;
        }

        [HttpGet("RandomCocktails")]
        public async Task<RandomCocktails> GetRandomCocktails()
        {
            var recipe = await _recipeClient.GetRandomCocktails();

            return recipe;
        }

        //[HttpGet]
        //public async Task<IEnumerable<RecipeFromDB>> Get(string Title = "croissans")
        //{
        //    return await _dynamoDBClient.  QueryAsync<RecipeFromDB>(Title).GetRemainingAsync();
        //}

        /* public async Task<GetItemResponse> GetRecipeFromDB()
         {
             var tablename = "recipes";
             var item = new GetItemRequest
             {
                 TableName = tablename,
                 Key = new Dictionary<string, AttributeValue>
                 {
                     { "title", new AttributeValue { S = "puff pastry" } },
                     { "instructions", new AttributeValue { S = "Sift flour. Pour ice water + vinegar into a separate bowl.\nAdd salt and egg. Mix.\nThen mix the liquid mixture with the flour and knead the dough.\nThe dough should be firm, soft and not sticky to your hands.\nPlace the dough on the table in flour and divide into two equal portions.\nRoll out the first piece as thin as possible, the thickness of the dough is 3-5 mm.\nDivide the soft butter in half. Put half on the rolled dough and put on a thick layer of dough.\nThen roll out the second part of the dough in the same way. Place the first rolled part on top so that the edges coincide, and brush the second part of the dough with butter.\nRoll the dough into a tight roll.\nThen roll the roll into a tight snail.\nWrap the dough snail in plastic wrap or in a bag. Place in the freezer for 15 min or in the refrigerator for at least 2 hours.\nRemove the dough from the refrigerator, flatten the snail on top and roll it out again.\nThe puff pastry is ready." } },
                     //{ "readyInMinutes", new AttributeValue { S = "25" } },
                     //{ "ingredients", new AttributeValue { S = "550-600 g. Flour (sift)\n300 ml. Water (icy)\n200 g butter or margarine\n1 Egg\n1 tsp Vinegar (9%)\n1/2 tsp Salt" } }
                  }
             };
             var response = await _dynamoDB.GetItemAsync(item);
             var result = response.Item.ToClass<RecipeFromDB>();
             return response;
         }*/
    }
}

