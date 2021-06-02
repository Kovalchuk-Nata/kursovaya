using kursovaya.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kursovaya.Clients
{
    public interface IDynamoDBClient
    {
        public Task<RecipeFromDB> GetRecipeByNameFromDB(string name); //пользователь добавил рецепт и ищет его в бд
       // public Task PostRecipeToDB(); // добавляем свой рецепт
        


        
    }
}
