using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using DotNetDeployments.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        public IActionResult Add()
        {           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectModel project)
        {
            var context = new DynamoDBContext(_dynamoDbClient);                        
            await context.SaveAsync(project);
            return RedirectToAction("Index");
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

        public async Task<IActionResult> Delete(string id, string projectName)
        {
            var context = new DynamoDBContext(_dynamoDbClient);
            
            // load project
            var projectModel = new ProjectModel { SolutionName = id, ProjectName = projectName };
            var project = await context.LoadAsync(projectModel);                        
            
            // delete project
            await context.DeleteAsync(project);
            return RedirectToAction("Index");
        }        
    }
}
