using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeRNDRequest.Extension
{
    public static class JArrayExtension
    {
        public static void EnumerateProperties(this JArray jArray, Action<JProperty> callback)
        {
            foreach (JObject resources in jArray.Children<JObject>())
            {
                foreach (JProperty property in resources.Properties())
                {
                    callback.Invoke(property);
                }
            }
        }
    }
}