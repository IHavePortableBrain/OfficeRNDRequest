using RestSharp;
using System;

namespace OfficeRNDRequest.Net
{
    internal class RestClientFactory
    {
        private RestClient _instance;

        public RestClient GetInstance()
        {
            return GetInstance(new Uri(null));
        }

        public RestClient GetInstance(String uriString)
        {
            return GetInstance(new Uri(uriString));
        }

        public RestClient GetInstance(Uri uri)
        {
            if (_instance == null)
            {
                _instance = new RestClient(uri);
            }
            return _instance;
        }
    }
}