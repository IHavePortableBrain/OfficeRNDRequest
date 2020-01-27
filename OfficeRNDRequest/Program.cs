using RestSharp;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeRNDRequest.Extension;
using OfficeRNDRequest.Net;

namespace OfficeRNDRequest
{
    internal class Program
    {
        static internal RestClientFactory RestClientFactory = new RestClientFactory();

        private static void Main(string[] args)
        {
            var client = RestClientFactory.GetInstance("https://identity.officernd.com/oauth/token");
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

            JArray.Parse(response.Content).EnumerateProperties(property => Console.WriteLine(property.Name));

            Console.Read();
        }
    }
}