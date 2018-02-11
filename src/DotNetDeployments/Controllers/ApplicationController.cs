using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DotNetDeployments.Controllers
{
    public class ApplicationController : Controller
    {
        IAmazonCodeDeploy AmazonCodeDeployClient { get; set; }

        public ApplicationController(IAmazonCodeDeploy amazonCodeDeployClient)
        {
            AmazonCodeDeployClient = amazonCodeDeployClient;
        }
        
        public async Task<IActionResult> Add(string id)
        {
            var application = await GetApplication(id);
            if (application == null)
            {
                return View();
            }
            else
            {
                return View("Edit");        
            }
        }

        public async Task<IActionResult> Edit(string id)
        {
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

        private async Task<GetApplicationResponse> GetApplication(string applicationName)
        {
            try
            {
                var getAppRequest = new GetApplicationRequest { ApplicationName = applicationName };
                var getAppResponse = await AmazonCodeDeployClient.GetApplicationAsync(getAppRequest);                
                return getAppResponse;
            }
            catch (ApplicationDoesNotExistException)
            {
                return null;
            }        
        }
    }   
}
