using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace OfficeRNDRequest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://identity.officernd.com/oauth/token");

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            string requestBody = @"client_id:o2cBTqaINCOWVBCd
client_secret:89c7n4zyKuegDE0wA2J40oDgcXmVUQvH
grant_type:client_credentials
scope:officernd.api.read officernd.api.write";
            byte[] requestBodyBytes = System.Text.Encoding.UTF8.GetBytes(requestBody);

            request.ContentLength = requestBodyBytes.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(requestBodyBytes, 0, requestBodyBytes.Length);
            }

            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            response.Close();
            Console.WriteLine("Запрос выполнен");
            Console.Read();
        }
    }
}