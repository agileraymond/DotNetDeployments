using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;
using DotNetDeployments.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DotNetDeployments.Tests.Controllers
{
    public class DeploymentConfigurationControllerShould
    {
        private readonly Mock<IAmazonCodeDeploy> _mockAmazonCodeDeploy;
        private readonly DeploymentConfigurationController _sut;

        public DeploymentConfigurationControllerShould()
        {
            _mockAmazonCodeDeploy = new Mock<IAmazonCodeDeploy>();
            _sut = new DeploymentConfigurationController(_mockAmazonCodeDeploy.Object);
        }        

        /// <summary>
        /// Test AppNameForm
        /// </summary>
        [Fact]
        public void ReturnViewWithNullObjectForAppNameForm()
        {
            var result = _sut.AppNameForm();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.True(viewResult.Model == null);
        }

        /// <summary>
        /// Test AppNewSave
        /// </summary>
        [Fact]
        public void ReturnViewWithoutNullObjectForAppNewSave()
        {
            _mockAmazonCodeDeploy
                .Setup(x => x.CreateApplicationAsync(It.IsAny<CreateApplicationRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new CreateApplicationResponse()));

            var result = _sut.AppNewSave(new CreateApplicationRequest());

            var viewResult = Assert.IsType<ViewResult>(result.Result);
            Assert.True(viewResult.Model == null);
        }
    }
}
