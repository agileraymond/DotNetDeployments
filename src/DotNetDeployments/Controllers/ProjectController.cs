using DotNetDeployments.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace DotNetDeployments.Controllers
{
    public class ProjectController : Controller
    {
        IAmazonDynamoDB AmazonDynamoDbClient { get; set; }

        public ProjectController(IAmazonDynamoDB amazonDynamoDbClient)
        {
            AmazonDynamoDbClient = amazonDynamoDbClient;            
        }

        public IActionResult Index()
        {
            // Define item attributes
            Dictionary<string, attributevalue=""> attributes = new Dictionary<string, attributevalue="">();
            
            attributes["SolutionName"] = new AttributeValue { S = "Mdb.Logger" };
            attributes["ProjectName"] = new AttributeValue { S = "Mdb.Utility" };
            attributes["ProjectType"] = new AttributeValue { N = "1" };
            
            // Create PutItem request
            PutItemRequest request = new PutItemRequest
            {
                TableName = "Projects",
                Item = attributes
            };
            
            AmazonDynamoDBClient.PutItem(request);
            
            return View();
        }
    }
}
