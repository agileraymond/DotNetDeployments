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

        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(CreateDeploymentRequest createDeploymentRequest)
        {            
            try
            {
                // need to move BundleType and RevisionType to UI
                createDeploymentRequest.Revision.S3Location.BundleType = Amazon.CodeDeploy.BundleType.Zip;
                createDeploymentRequest.Revision.RevisionType = Amazon.CodeDeploy.RevisionLocationType.S3;
                var createDeploymentResponse = await AmazonCodeDeployClient.CreateDeploymentAsync(createDeploymentRequest);    
            }
            catch (System.Exception ex)
            {   
                throw;
            }

            return RedirectToAction("Index", "Project");
        }
    }
}
