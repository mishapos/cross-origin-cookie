using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Company.Function
{
    public static class demo
    {
        [FunctionName("demo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var response = new HttpResponseMessage();
            var guid = Guid.NewGuid().ToString();
            var cookieValue = $"{guid};HttpOnly;Secure;Path=/;SameSite=None";
            response.Headers.Add("SetCookie", $"HeaderCookie={cookieValue}");
            return response;
        }
    }
}
