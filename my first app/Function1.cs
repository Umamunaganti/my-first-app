using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using my_first_app.MODELS;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace my_first_app
{
    public static class Function1
    {
        //[FunctionName("Function1")]
        //public static IActionResult Run(
        //    [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
        //    //ILogger log,
        //[CosmosDB("Employeedatabase", "EmployeeContainer", ConnectionStringSetting = "CosmosDBConnection",SqlQuery = "SELECT * FROM c order by c._ts desc")]
        //IEnumerable<Employee> todos)
        //{
        //    //log.Info("Getting todo list items");
        //    return new OkObjectResult(todos);
        //    //log.LogInformation("C# HTTP trigger function processed a request.");

        //    //var inputValue = await req.Content.ReadAsAsync<JObject>();
        //    ////this is a new program
        //    //string requestBody = await new StreamReader((string)inputValue).ReadToEndAsync();
        //    ////dynamic data = JsonConvert.DeserializeObject(requestBody);

        //    ////string responseMessage = string.IsNullOrEmpty(name)
        //    ////    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
        //    ////    : $"Hello, {name}. This HTTP triggered function executed successfully.";

        //    //return new OkObjectResult("");
        //}

        //    [FunctionName("CosmosDb_GetTodos")]
        //    public static IActionResult GetTodos(
        //[HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "todo4")] HttpRequest req,
        //[CosmosDB(
        //    databaseName: "tododb",
        //    collectionName: "tasks",
        //    ConnectionStringSetting = "CosmosDBConnection",
        //   // SqlQuery = "SELECT * FROM c order by c._ts desc"
        //   Id ="{id}"
        //        )]
        //    Employee todos,
        //TraceWriter log)
        //    {
        //        log.Info("Getting todo list items");
        //        return new OkObjectResult(todos);
        //    }


        [FunctionName("CreateProvider")]
        public static async Task<dynamic> CreateProvider(
         [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "CreateProvider")] HttpRequestMessage req,
         ILogger log,
         [CosmosDB("Employeedatabase", "EmployeeContainer", ConnectionStringSetting = "CosmosDBConnection")] IDocumentClient client
        )
        {
            try
            {
                var input = await req.Content.ReadAsAsync<Employee>();
                Uri COLLECTION = UriFactory.CreateDocumentCollectionUri("Employeedatabase", "EmployeeContainer");
                return await client.CreateDocumentAsync(COLLECTION, input);

            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
                return null;
            }
        }



        [FunctionName("updateProvider")]
        public static async Task<dynamic> updateProvider(
         [HttpTrigger(AuthorizationLevel.Function, "put", Route = "updateProvider")] HttpRequestMessage req,
         ILogger log,
         [CosmosDB("Employeedatabase", "EmployeeContainer", ConnectionStringSetting = "CosmosDBConnection")] IDocumentClient client
        )
        {
            try
            {
                var input = await req.Content.ReadAsAsync<Employee>();
                Uri docUri = UriFactory.CreateDocumentUri("Employeedatabase", "EmployeeContainer", input.Employeeid);
               
                
                return await client.ReplaceDocumentAsync(docUri, input);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
                return null;
            }
        }




       
    }

}




