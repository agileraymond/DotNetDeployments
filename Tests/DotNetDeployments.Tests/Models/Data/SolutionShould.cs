using Xunit;

namespace DotNetDeployments.Tests.Models.Data
{
    public class SolutionShould
    {
        /// <summary>
        /// These are meant to check the setter and getter
        /// http://blog.ploeh.dk/2013/03/08/test-trivial-code/
        /// </summary>
        /// <param name="expectedSolutionId"></param>
        /// <param name="expectedSolutionName"></param>
        [Theory]
        [InlineData(1, "Solution 1")]
        [InlineData(2, "Solution 2")]
        public void ReturnTheInitializationValue(int expectedSolutionId, string expectedSolutionName)
        {
            var solution = new Solution
            {
                SolutionId = expectedSolutionId,
                SolutionName = expectedSolutionName
            };

            Assert.Equal(expectedSolutionId, solution.SolutionId);
            Assert.Equal(expectedSolutionName, solution.SolutionName);
        }

        /// <summary>
        /// Test empty constructor initialization
        /// </summary>
        [Fact]
        public void ReturnTheDefaultPropertyValuesWithEmptyConstructorInitialization()
        {
            var solution = new Solution();

            Assert.Equal(0, solution.SolutionId);
            Assert.Equal(null, solution.SolutionName);
        }
    }
}
