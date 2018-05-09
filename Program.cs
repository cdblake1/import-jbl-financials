using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{    class Program
    {
        private const string API_URL = "https://api.iextrading.com/1.0/stock/JBL/stats?";
        private static readonly HttpClient client = new HttpClient();
        private static Dictionary<string, string> parameters = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            parameters.Add("symbols", "JBL");
            parameters.Add("types", "stats");

            var apiCall = buildAPICall(parameters);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/JSON"));


        }

        public static string buildAPICall(Dictionary<string, string> parameters)
        {
            var parametersString = "";
            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                parametersString += parameter.Key + "=" + parameter.Value
                    + (parameter.Key.Equals("api_call") ? "" : "&");
            }

            return API_URL + parametersString;
        }

        [DataContract]
        class CompanyFinancialData
        {
            [DataMember]
            public string sharesOutstanding;

            [DataMember]
            public int price;
        }
    }
}

