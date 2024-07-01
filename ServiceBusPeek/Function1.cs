using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PushVehicleIndexToServiceBus;

namespace ServiceBusPeek
{
    public static class PeekMessage
    {
        [FunctionName("Peek")]
        public static async Task<IActionResult> Peek(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C#  trigger function processed a request.");

            string responseMessage = ServieBusQueue.PeekMessageAsync();
            return new OkObjectResult(responseMessage);
        }
    }
}
