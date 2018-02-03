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
        
        public IActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var getAppRequest = new GetApplicationRequest { ApplicationName = id };
                var getAppResponse = await AmazonCodeDeployClient.GetApplicationAsync(getAppRequest);                
            }
            catch (ApplicationDoesNotExistException)
            {
                return RedirectToAction("Add");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateApplicationRequest createAppRequest)
        {
            try
            {
                var createAppResponse = await AmazonCodeDeployClient.CreateApplicationAsync(createAppRequest);    
            }
            catch (System.Exception)
            {         
            }

            return View();
        }
        
        public IActionResult AddDeploymentGroup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDeploymentGroup(CreateDeploymentGroupRequest createDeploymentGroupRequest)
        {            
            try
            {
                var createDeploymentGroupResponse = await AmazonCodeDeployClient.CreateDeploymentGroupAsync(createDeploymentGroupRequest);    
            }
            catch (System.Exception ex)
            {   
                throw;
            }

            return View();
        }

        public IActionResult AddDeployment()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddDeployment(CreateDeploymentRequest createDeploymentRequest)
        {            
            try
            {
                var revision = new Amazon.CodeDeploy.Model.RevisionLocation();
                revision.RevisionType = Amazon.CodeDeploy.RevisionLocationType.S3;
                
                var s3location = new Amazon.CodeDeploy.Model.S3Location();
                s3location.Bucket = "s3://dotnetdeploymentbucket";
                s3location.BundleType = Amazon.CodeDeploy.BundleType.Zip;
                s3location.Key = "Archive.zip";
                revision.S3Location = s3location; 
                                
                createDeploymentRequest.Revision = revision;
                var createDeploymentResponse = await AmazonCodeDeployClient.CreateDeploymentAsync(createDeploymentRequest);    
            }
            catch (System.Exception ex)
            {   
                throw;
            }

            return View();
        }
    }   
}
