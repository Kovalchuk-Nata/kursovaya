﻿using kursovaya.Models;
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


        public async Task<RandomRecipe> GetRandonRecipe()
        {
            var response = await client.GetAsync("/recipes/random?apiKey=1686191358ed4208988e2f8fd63fd3ba&number=1");
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
       
        public async Task<RecipeFromDB> GetHealthyFood()
        {
            var response = await client.GetAsync($"/recipes/complexSearch?query=pasta&number=2&apiKey={Const.apiKey}&addRecipeInformation=true&fillIngredients=true");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<RecipeFromDB>(content);
            return result;
        }


    }
}
