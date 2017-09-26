using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Amazon.Lambda.Core;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
// test comment
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSLambda1
{
    public class Function
    {

        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient();
        static string tableName = "myDynamoDB";

        public async Task<Document> FunctionHandler()
        {
            Table myDynamoTable = Table.LoadTable(client, "myDynamoTable");
            Document myDocument = await myDynamoTable.GetItemAsync(3);
            return myDocument;

        }
    }
}
