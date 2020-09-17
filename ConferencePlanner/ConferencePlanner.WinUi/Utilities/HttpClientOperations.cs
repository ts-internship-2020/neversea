﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Formatting;
using System.Web.Http;
using ConferencePlanner.Abstraction.Model;

namespace ConferencePlanner.WinUi.Utilities
{
    public class HttpClientOperations
    {
        public static HttpClient httpClient = HttpClientFactory.Create();

        public static async Task<List<T>> GetOperation<T>(string url)
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
            List<T> returnedList = new List<T>();
            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var content = httpResponseMessage.Content;
                var data = await content.ReadAsStringAsync();
                returnedList = (List<T>)JsonConvert.DeserializeObject<IEnumerable<T>>(data);
                Console.WriteLine("Lista returnata are marimea " + returnedList.Count);
                return returnedList;
            }
            else
            {
                throw new Exception("Couldn't load " + typeof(T).ToString());
                return returnedList;
            }
        }
        public static async Task<T> GetOperationOneElement<T>(string url)
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
            T returnedObject = (T)Activator.CreateInstance(typeof(T));
            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var content = httpResponseMessage.Content;
                var data = await content.ReadAsStringAsync();
                returnedObject = (T)JsonConvert.DeserializeObject<T>(data);
                return returnedObject;
            }
            else
            {
                throw new Exception("Couldn't load " + typeof(T).ToString());
                return returnedObject;
            }
        }

        public static async void PutOperation<T>(string url, T obj)
        {
            HttpClient httpClient = HttpClientFactory.Create();

            HttpResponseMessage res;

            res = await httpClient.PostAsync(url, obj, new JsonMediaTypeFormatter());
        }

        public static async void PutAsyncOperation<T>(string url, T obj)
        {
            HttpClient httpClient = HttpClientFactory.Create();

            HttpResponseMessage res;

            string serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(serializedObject, Encoding.UTF8, "application/json");
            res = await httpClient.PutAsync(url, httpContent);
        }


        public static async void PostOperation<T>(string url, T obj)
        {
            var response = await httpClient.PostAsync(url, obj, new JsonMediaTypeFormatter());
        }


        public static async void DeleteOperation<T>(string url, T obj)
        {
            HttpClient httpClient = HttpClientFactory.Create();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url),
                Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
            };
            var response = await httpClient.SendAsync(request);
        }

        //public static async void DeleteOperation<T>(string url, T obj)
        //{
        //    HttpClient httpClient = HttpClientFactory.Create();

        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Delete,
        //        RequestUri = new Uri(url),
        //        Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
        //    };
        //    var response = await httpClient.SendAsync(request);

        //}
    }
}
