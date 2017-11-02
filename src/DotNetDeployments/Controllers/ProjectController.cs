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
        
        public async Task<IActionResult> Index()
        {   
            var projects = await GetProjects();  
            return View(projects);
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

        private async Task<List<ProjectModel>> GetProjects()
        {            
            var projects = new List<ProjectModel>();
            var context = new DynamoDBContext(_dynamoDbClient);
            var conditions = new List<ScanCondition>();
            var scanRequest = context.ScanAsync<ProjectModel>(conditions);

            while (!scanRequest.IsDone)
            {
                projects.AddRange(await scanRequest.GetNextSetAsync());
            }

            return projects;            
        }        
    }
}
