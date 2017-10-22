using DotNetDeployments.Models;
using Xunit;

namespace DotNetDeployments.Tests
{
    public class ErrorViewModelShould
    {
        /// <summary>
        /// Test different possibilities of ShowRequestId value
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="expectedShowRequestId"></param>
        [Theory]
        [InlineData("", false)]
        [InlineData(null, false)]
        [InlineData(" ", true)]
        [InlineData("1a", true)]
        [InlineData(" 1a", true)]
        public void ReferToRequestIdToGetShowRequestId(string requestId, bool expectedShowRequestId)
        {
            var errorViewModel = new ErrorViewModel
            {
                RequestId = requestId
            };

            Assert.Equal(expectedShowRequestId, errorViewModel.ShowRequestId);
        }

        /// <summary>
        /// These are meant to check the setter and getter of properties that have not been tested
        /// http://blog.ploeh.dk/2013/03/08/test-trivial-code/
        /// </summary>
        /// <param name="expectedRequestId"></param>
        [Theory]
        [InlineData("1a")]
        [InlineData(" ")]
        public void ReturnTheInitializationValue(string expectedRequestId)
        {
            var errorViewModel = new ErrorViewModel
            {
                RequestId = expectedRequestId
            };

            Assert.Equal(expectedRequestId, errorViewModel.RequestId);
        }

        /// <summary>
        /// Test empty constructor initialization
        /// </summary>
        [Fact]
        public void ReturnTheDefaultPropertyValuesWithEmptyConstructorInitialization()
        {
            var errorViewModel = new ErrorViewModel();

            Assert.Equal(null, errorViewModel.RequestId);
            Assert.False(errorViewModel.ShowRequestId);
        }
    }
}
