using DotNetDeployments.Models;
using Xunit;

namespace DotNetDeployments.Tests
{
    public class ErrorViewModelShould
    {
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
    }
}
