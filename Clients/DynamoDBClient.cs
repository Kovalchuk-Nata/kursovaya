using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using kursovaya.Extentions;
using kursovaya.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kursovaya.Clients
{
    public class DynamoDBClient : IDynamoDBClient
    {
        public string _tableName;
        public readonly IAmazonDynamoDB _dynamoDB;
        public DynamoDBClient(IAmazonDynamoDB dynamoDB)
        {
            _dynamoDB = dynamoDB;
            _tableName = Const.tableName;
        }
        public async Task<RecipeFromDB> GetRecipeByNameFromDB(string name)
        {
            var item = new GetItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "title", new AttributeValue { S = name } },
                   // { "instructions", new AttributeValue { S = "Sift flour. Pour ice water + vinegar into a separate bowl.\nAdd salt and egg. Mix.\nThen mix the liquid mixture with the flour and knead the dough.\nThe dough should be firm, soft and not sticky to your hands.\nPlace the dough on the table in flour and divide into two equal portions.\nRoll out the first piece as thin as possible, the thickness of the dough is 3-5 mm.\nDivide the soft butter in half. Put half on the rolled dough and put on a thick layer of dough.\nThen roll out the second part of the dough in the same way. Place the first rolled part on top so that the edges coincide, and brush the second part of the dough with butter.\nRoll the dough into a tight roll.\nThen roll the roll into a tight snail.\nWrap the dough snail in plastic wrap or in a bag. Place in the freezer for 15 min or in the refrigerator for at least 2 hours.\nRemove the dough from the refrigerator, flatten the snail on top and roll it out again.\nThe puff pastry is ready." } },
                    //{ "readyInMinutes", new AttributeValue { S = "25" } },
                    //{ "ingredients", new AttributeValue { S = "550-600 g. Flour (sift)\n300 ml. Water (icy)\n200 g butter or margarine\n1 Egg\n1 tsp Vinegar (9%)\n1/2 tsp Salt" } }
                 }
            };
            var response = await _dynamoDB.GetItemAsync(item);
            if (response.Item == null || !response.IsItemSet)
                return null;
            var result = response.Item.ToClass<RecipeFromDB>();
            return result;
        }

        //public Task PostRecipeToDB()
        //{
        //    var request = new PutItemRequest
        //    {
        //        TableName = _tableName,
        //        Item = new Dictionary<string, AttributeValue>()
        //    {
        //        { "Title", new AttributeValue {
        //              S = "butterbread"
        //          }},
        //        { "ReadyInMinutes", new AttributeValue {
        //              S = "25"
        //          }},
        //            { "Ingredients", new AttributeValue {
        //              S = "butter, bread"
        //          }},
        //            { "Instructions", new AttributeValue {
        //              S = "butter + bread = buttebread"
        //          }},

        //    }
        //    };
        //    _dynamoDB.PutItemAsync(request);// .PutItem(request);
        //}


    }
}
