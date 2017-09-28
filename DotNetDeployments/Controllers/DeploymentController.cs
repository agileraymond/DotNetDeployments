using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetDeployments.Models;
using Amazon.CodeDeploy;

namespace DotNetDeployments.Controllers
{
    public class DeploymentController : Controller
    {
        public IActionResult Index()
        {            
            var codeDeploy = new AmazonCodeDeployClient();

            return View();
        }      
    }
}
