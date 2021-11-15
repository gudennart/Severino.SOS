using Blazored.SessionStorage;
using Severino.SOS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Severino.SOS.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _HttpClient;
        private readonly ISessionStorageService _SessionStorage;

        public HttpService(HttpClient client, ISessionStorageService session)
        {
            _HttpClient = client;
            _SessionStorage = session;
        }

        public async Task<Response> DeleteAsync(string URL, Dictionary<string, string> Parms)
        {
            _HttpClient.DefaultRequestHeaders.Clear();
            var msm = new MemoryStream();
            Response resp = new();
            if (Parms != null) SetParameters(Parms);

            if (URL != "login") _HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + await _SessionStorage.GetItemAsync<string>("token"));

            var result = await _HttpClient.DeleteAsync(URL);
            resp.StatusCode = result.StatusCode;
            if (result.StatusCode == HttpStatusCode.OK || result.StatusCode == HttpStatusCode.NoContent || result.StatusCode == HttpStatusCode.Accepted)
            {
                resp.Content = await result.Content.ReadAsStringAsync();
            }
            return resp;
        }

        public async Task<Response> GetAsync(string URL, Dictionary<string, string> Parms, object body)
        {
            _HttpClient.DefaultRequestHeaders.Clear();
            Response resp = new();
            if (Parms != null) SetParameters(Parms);
            var result = new HttpResponseMessage();
            if (URL != "login") _HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + await _SessionStorage.GetItemAsync<string>("token"));
            if (body == null)
            {
                result = await _HttpClient.GetAsync(URL);
            }
            else
            {
                var stringObj = JsonSerializer.Serialize(body);
                var StringBody = new StringContent(stringObj, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(_HttpClient.BaseAddress + URL),
                    Content = StringBody,
                };
                result = await _HttpClient.SendAsync(request);
            }

            resp.StatusCode = result.StatusCode;
            if (result.StatusCode == HttpStatusCode.OK || result.StatusCode == HttpStatusCode.NoContent || result.StatusCode == HttpStatusCode.Accepted)
                resp.Content = await result.Content.ReadAsStringAsync();
            return resp;
        }

        public async Task<Response> PostAsync(string URL, object Body, Dictionary<string, string> Parms)
        {
            _HttpClient.DefaultRequestHeaders.Clear();
            Response resp = new();

            if (Parms != null) SetParameters(Parms);

            if (URL != "tokens" && URL != "users") _HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + await _SessionStorage.GetItemAsync<string>("token"));

            var stringObj = JsonSerializer.Serialize(Body);
            var StringBody = new StringContent(stringObj, Encoding.UTF8, "application/json");
            var result = await _HttpClient.PostAsync(URL, StringBody);
            resp.StatusCode = result.StatusCode;
            resp.Content = await result.Content.ReadAsStringAsync();
            return resp;
        }

        public async Task<Response> PutAsync(string URL, string ID, object Body, Dictionary<string, string> Parms)
        {
            _HttpClient.DefaultRequestHeaders.Clear();
            Response resp = new();
            if (Parms != null) SetParameters(Parms);
            if (URL != "login") _HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + await _SessionStorage.GetItemAsync<string>("token"));

            if (ID != null) URL += "/" + ID;

            var stringObj = JsonSerializer.Serialize(Body);
            var StringBody = new StringContent(stringObj, Encoding.UTF8, "application/json");
            var result = await _HttpClient.PutAsync(URL, StringBody);
            resp.StatusCode = result.StatusCode;
            resp.Content = await result.Content.ReadAsStringAsync();
            return resp;
        }

        private void SetParameters(Dictionary<string, string> parms)
        {
            _HttpClient.DefaultRequestHeaders.Clear();
            foreach (var parm in parms)
            {
                _HttpClient.DefaultRequestHeaders.Add(parm.Key, parm.Value);
            }
        }
    }
}
