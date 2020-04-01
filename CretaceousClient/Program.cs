using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CretaceousClient
{
    public class Program
    {
    public static void Main(string[] args)
    {
      var apiCallTask = ApiHelper.ApiCall("[YOUR-API-KEY-HERE]");
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Console.WriteLine(jsonResponse["results"]);
    }

    // class ApiHelper
    // {
    //     public static async Task<string> ApiCall(string apiKey)
    //     {
    //     RestClient client = new RestClient("https://api.nytimes.com/svc/topstories/v2");
    //     RestRequest request = new RestRequest($"home.json?api-key={apiKey}", Method.GET);
    //     var response = await client.ExecuteTaskAsync(request);
    //     return response.Content;
    //     }
    // }
}
