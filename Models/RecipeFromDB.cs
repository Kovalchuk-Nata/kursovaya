using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kursovaya.Models
{
    public class RecipeFromDB
    {
        [DynamoDBProperty("Title")]
        [DynamoDBHashKey]
        public Guid Title { get; set; }

        [DynamoDBProperty("ReadyInMinutes")]
        public string ReadyInMinutes { get; set; }

        [DynamoDBProperty("Ingredients")]
        public string Ingredients { get; set; }

        [DynamoDBProperty("Instructions")]
        public string Instructions { get; set; }

    }
}
