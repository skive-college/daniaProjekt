using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Calculator
{
    public static class Add
    {
        [FunctionName("Add")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string dataO = req.Query["numbers"];
        //    string [] arr = req.Query["numbers"];
      //      int [] numbers = Array.ConvertAll(arr, int.Parse); ;

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            /*  if (numbers == null)
              {
                  arr = data?.numbers;
                  numbers = Array.ConvertAll(arr, int.Parse); ;
              }

              long sum = 0;
              for (int i = 0; i < numbers.Length; i++)
              {
                  sum += numbers[i];
              }
            */
            dataO ??= data?.numbers;
            
            string responseMessage = string.IsNullOrEmpty(dataO)
                ? "You nee to pass the numbers to be added separated by commas ','"
                : (dataO.Split(',').Select(x => int.Parse(x)).ToArray()).Sum().ToString();

            return new OkObjectResult(responseMessage);
        }
    }
}
