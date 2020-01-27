using RestSharp;
using System;
using Newtonsoft.Json;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace OfficeRNDRequest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new RestClient("https://identity.officernd.com/oauth/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("client_id", "o2cBTqaINCOWVBCd");
            request.AddParameter("client_secret", "89c7n4zyKuegDE0wA2J40oDgcXmVUQvH");
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("scope", "officernd.api.read officernd.api.write");
            IRestResponse response = client.Execute(request);

            client.BaseUrl = new Uri("https://app.officernd.com/i/organizations/vsgate-officernd-trial/resources");
            request = new RestRequest(Method.GET);
            dynamic responseBodyParsed = JsonConvert.DeserializeObject(response.Content);
            request.AddHeader("Authorization", (string)responseBodyParsed.access_token);
            response = client.Execute(request);
            JArray resourceObjects = JArray.Parse(response.Content);

            foreach (JObject resources in resourceObjects.Children<JObject>())
            {
                foreach (JProperty property in resources.Properties())
                {
                    Console.WriteLine(property.Name);
                }
            }

            Console.Read();
        }
    }
}