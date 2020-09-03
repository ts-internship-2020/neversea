using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace ConferencePlanner.WinUi.Utilities
{
    public class HttpClientOperations
    {
        public static async Task<List<T>> GetOperation<T>(string url)
        {
            HttpClient httpClient = HttpClientFactory.Create();

            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
            List<T> returnedList = new List<T>(); 
            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var content = httpResponseMessage.Content; 
                var data = await content.ReadAsStringAsync();
                returnedList = (List<T>)JsonConvert.DeserializeObject<IEnumerable<T>>(data);
                return returnedList;
            } 
            else
            {
                throw new Exception("Couldn't load " + typeof(T).ToString());
                return returnedList;
            }
        }

        public static async Task<T> PutOperation<T>(string url)
        {
            HttpClient httpClient = HttpClientFactory.Create();

            HttpResponseMessage res; 

            res = await httpClient.PutAsJsonAsync(url, new T);

            if(res.IsSuccessStatusCode)

            /*var res = new HttpRequestMessage(HttpMethod.Put, url);
            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(req);

            if (httpRequestMessage.StatusCode == HttpStatusCode.OK)
            {
                var content = httpResponseMessage.Content;
                var data = await content.ReadAsStringAsync();
                returnedList = (List<T>)JsonConvert.DeserializeObject<IEnumerable<T>>(data);
                return returnedList;
            }
            else
            {
                throw new Exception("Couldn't load " + typeof(T).ToString());

            }

            HttpResponseMessage httpResponseMessage = await httpClient.PutAsync(url, content);*/
        }


    }
}
