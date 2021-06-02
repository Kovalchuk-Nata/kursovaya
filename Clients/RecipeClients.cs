using kursovaya.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace kursovaya.Clients
{
    //
    public class RecipeClients
    {
        private HttpClient client;
        private static string adress;
        private static string apiKey;

        public RecipeClients()
        {
            adress = Const.adress;
            apiKey = Const.apiKey;

            client = new HttpClient();
            client.BaseAddress = new Uri(adress);
        }


        public async Task<RandomRecipe> GetRandomRecipe()
        {
            var response = await client.GetAsync($"/recipes/random?apiKey={Const.apiKey}&number=1");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<RandomRecipe>(content);
            return result;
        }

        public async Task<RecipeByName> GetRecipeByName(string title)
        {
            var response = await client.GetAsync($"/recipes/complexSearch?query={title}&number=2&apiKey={Const.apiKey}&addRecipeInformation=true&fillIngredients=true");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<RecipeByName>(content);
            return result;
        }      

        public async Task<RecipeByIngredient> GetRecipeByIngredient(string ingredient)
        {
            var response = await client.GetAsync($"recipes/complexSearch?includeIngredients={ingredient}&apiKey={Const.apiKey}&addRecipeInformation=true&number=1&fillIngredients=true");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<RecipeByIngredient>(content);
            return result;
        }

        public async Task<RecipeFromDB> GetHealthyFood(string ingredient)
        {
            var response = await client.GetAsync($"recipes/complexSearch?includeIngredients={ingredient}&apiKey={Const.apiKey}&addRecipeInformation=true&fillIngredients=true&number=2");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<RecipeFromDB>(content);
            return result;
        }

        public async Task<RandomCocktail> GetRandomCocktail(int offset)
        {
            var response = await client.GetAsync($"recipes/complexSearch?query=cocktail&apiKey={Const.apiKey}&number=1&addRecipeInformation=true&fillIngredients=true&offset={offset}");///recipes/random?apiKey={Const.apiKey}&number=1&tags=cocktails");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<RandomCocktail>(content);
            return result;
        }

    }
}
