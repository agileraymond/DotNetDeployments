using DotNetDeployments.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace DotNetDeployments.Controllers
{
    public class ProjectController : Controller
    {
        private IAmazonDynamoDB _dynamoDbClient;

        public ProjectController(IAmazonDynamoDB dynamoDbClient)
        {
            _dynamoDbClient = dynamoDbClient;            
        }
        
        public IActionResult Index()
        {
            return View();
        }

        /* 
        public async Task<IActionResult> Create()
        {            
            // Define item attributes
            var attributes = new Dictionary<string, AttributeValue>();
            
            attributes["SolutionName"] = new AttributeValue { S = "Mdb.Logger" };
            attributes["ProjectName"] = new AttributeValue { S = "Mdb.Utility" };
            attributes["ProjectType"] = new AttributeValue { N = "1" };
            
            // Create PutItem request
            var request = new PutItemRequest
            {
                TableName = "Projects",
                Item = attributes
            };            
            
            var result = await _dynamoDbClient.PutItemAsync(request);         

            return View();
        }
        */
    }
}
