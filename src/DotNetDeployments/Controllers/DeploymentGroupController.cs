using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DotNetDeployments.Controllers
{
    public class DeploymentGroupController : Controller
    {
        IAmazonCodeDeploy AmazonCodeDeployClient { get; set; }

        public DeploymentGroupController(IAmazonCodeDeploy amazonCodeDeployClient)
        {
            AmazonCodeDeployClient = amazonCodeDeployClient;
        }
        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateDeploymentGroupRequest createDeploymentGroupRequest)
        {            
            try
            {
                var createDeploymentGroupResponse = await AmazonCodeDeployClient.CreateDeploymentGroupAsync(createDeploymentGroupRequest);    
            }
            catch (System.Exception ex)
            {   
                throw;
            }

            return RedirectToAction("Index", "Project");
        }
    }   
}
