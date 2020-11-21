using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Calculator;

namespace CalculatorTest
{
    public class UnitTest1
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Theory]
        [InlineData ("numbers", "1,2,3,4", "10")]
        [InlineData("numbers", "1,-2,3,-4", "-2")]
        [InlineData("", "", "You nee to pass the numbers to be added separated by commas ','")]
        public async void Http_trigger_should_return_sum(string queryStringKey, string queryStringValue, string result)
        {
            var request = TestFactory.CreateHttpRequest(queryStringKey, queryStringValue);
            var response = (OkObjectResult)await Add.Run(request, logger);
            Assert.Equal(result, response.Value);
        }

   /*     [Fact]
        public async void Http_trigger_should_return_known_string()
        {
            var request = TestFactory.CreateHttpRequest("name", "Bill");
            var response = (OkObjectResult)await Add.Run(request, logger);
            Assert.Equal("Hello, Bill. This HTTP triggered function executed successfully.", response.Value);
        }

        [Theory]
        [MemberData(nameof(TestFactory.Data), MemberType = typeof(TestFactory))]
        public async void Http_trigger_should_return_known_string_from_member_data(string queryStringKey, string queryStringValue)
        {
            var request = TestFactory.CreateHttpRequest(queryStringKey, queryStringValue);
            var response = (OkObjectResult)await Add.Run(request, logger);
            Assert.Equal($"Hello, {queryStringValue}. This HTTP triggered function executed successfully.", response.Value);
        }
   */
        
    }
}
