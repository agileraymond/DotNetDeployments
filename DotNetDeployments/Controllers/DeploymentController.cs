using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DotNetDeployments.Controllers
{
    public class DeploymentController : Controller
    {
        IAmazonCodeDeploy AmazonCodeDeployClient { get; set; }

        public DeploymentController(IAmazonCodeDeploy amazonCodeDeployClient)
        {
            AmazonCodeDeployClient = amazonCodeDeployClient;
        }

        public async Task<IActionResult> Index()
        {
            var createAppRequest = new CreateApplicationRequest
            {
                ApplicationName = DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")
            };

            var createAppResponse = await AmazonCodeDeployClient.CreateApplicationAsync(createAppRequest);
            return View();
        } 
        
        public IActionResult AppNameForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AppNewSave(CreateApplicationRequest applicationRequest)
        {
            var createAppResponse = await AmazonCodeDeployClient.CreateApplicationAsync(applicationRequest);

            return View(Index());
        }
    }
}
