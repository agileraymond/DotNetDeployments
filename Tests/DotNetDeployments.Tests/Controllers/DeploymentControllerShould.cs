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
    public class DeploymentControllerShould
    {
        private readonly Mock<IAmazonCodeDeploy> _mockAmazonCodeDeploy;
        private readonly DeploymentController _sut;

        public DeploymentControllerShould()
        {
            _mockAmazonCodeDeploy = new Mock<IAmazonCodeDeploy>();
            _sut = new DeploymentController(_mockAmazonCodeDeploy.Object);
        }

        /// <summary>
        /// Test Index
        /// </summary>
        [Fact]
        public void ReturnViewWithNullObjectForIndex()
        {
            _mockAmazonCodeDeploy
                .Setup(x => x.CreateApplicationAsync(It.IsAny<CreateApplicationRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new CreateApplicationResponse()));

            var result = _sut.Index();

            var viewResult = Assert.IsType<ViewResult>(result.Result);
            Assert.True(viewResult.Model == null);
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
            Assert.True(viewResult.Model != null);
        }
    }
}
