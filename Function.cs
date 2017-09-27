using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Amazon;
using Amazon.Lambda.Core;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.DataModel;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
// test comment
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSLambda1
{
    public class Function
    {

        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient();
        DynamoDBContext dynamoDBContext = new DynamoDBContext(client);
        static string tableName = "myDynamoTable";

        public Task<List<Amazon.DynamoDBv2.DocumentModel.Document>> FunctionHandler()
        {
            Table myDynamoTable = Table.LoadTable(client, tableName);

            //Document myDocument = await myDynamoTable.GetItemAsync(1);

            return AllTheThings();

        }

        public async Task<List<Amazon.DynamoDBv2.DocumentModel.Document>> AllTheThings()
        {
            Table myDynamoTable = Table.LoadTable(client, tableName);
            ScanFilter scanFilter = new ScanFilter();
            scanFilter.AddCondition("value", ScanOperator.IsNotNull);
            Search search = myDynamoTable.Scan(scanFilter);
            List<Document> documentList = new List<Document>();
                documentList = await search.GetNextSetAsync();
                return documentList;
        }
    }
}
