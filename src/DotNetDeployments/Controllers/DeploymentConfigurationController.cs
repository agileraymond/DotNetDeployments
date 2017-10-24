using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DotNetDeployments.Controllers
{
    public class DeploymentConfigurationController : Controller
    {
        IAmazonCodeDeploy AmazonCodeDeployClient { get; set; }

        public DeploymentConfigurationController(IAmazonCodeDeploy amazonCodeDeployClient)
        {
            AmazonCodeDeployClient = amazonCodeDeployClient;
        }
        
        public IActionResult AppNameForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AppNewSave(CreateApplicationRequest applicationRequest)
        {
            var createAppResponse = await AmazonCodeDeployClient.CreateApplicationAsync(applicationRequest);

            return View();
        }
    }
}
