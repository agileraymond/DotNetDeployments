using DotNetDeployments.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.DataModel;
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

        public void SaveProject()
        {
            /*
            it is better to use DynamoDBContext to save, edit, delete documents 
            var context = new DynamoDBContext(_dynamoDbClient);
            
            var project = new ProjectModel
            {
                SolutionName = "raysolution",
                ProjectName = "myprojecy",
                ProjectType = ProjectType.Web
            };
            await context.SaveAsync(project);
            */
        }        
    }
}
