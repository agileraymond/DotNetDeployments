﻿using Amazon.CodeDeploy;
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
    }
}
