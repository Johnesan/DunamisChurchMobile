using DunamisChurchMobile.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DunamisChurchMobile.Services
{
    class ChurchPlusApis
    {
        #region Urls and parameters
        public static string CID = "899AF4B9-A222-447C-8609-F651DBF343C6";
        public static string AppKey = "899AF4B9-A222-447C-8609-F651DBF343C6";
        public static string GetAllEventsApiUrl = "http://dunamisapi.azurewebsites.net/api/EventsServiceApiController/getAllEvents";
        public static string GetSingleEventApiUrl = "http://dunamisapi.azurewebsites.net/api/EventsServiceApiController/getSingleEvent?id=";
        public static string GetAllTestimoniesApiUrl = "http://dunamisapi.azurewebsites.net/api/Testimonies/GetTestimoniesData";
        public static string PostTestimonyUrl = "http://dunamisapi.azurewebsites.net/api/Testimonies/PostTestimony";
        public static string GetAllHomeChurchesUrl = "http://dunamisapi.azurewebsites.net/api/HouseFellowship/GetHouseFellowships";
        public static string SearchHomeChurchUrl = "http://dunamisapi.azurewebsites.net/api/HouseFellowship/SearchHouseFellowships?name=";
        public static string GetSeedOfDestinyUrl = "http://dunamisgospel.org/mobile-sod/read.php";
        #endregion

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes, 0, base64EncodedBytes.Length);
        }

        public async Task<List<Event>> GetAllEvents()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("CID", CID);
            var response = await httpClient.GetAsync(GetAllEventsApiUrl);
            HttpContent content = response.Content;
            var json = await content.ReadAsStringAsync();
            var events = JsonConvert.DeserializeObject<List<Event>>(json);
            return events;
        }

        public async Task<Event> GetSingleEvent()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("CID", CID);
            var response = await httpClient.GetAsync(GetSingleEventApiUrl);
            HttpContent content = response.Content;
            var json = await content.ReadAsStringAsync();
            var Event = JsonConvert.DeserializeObject<Event>(json);
            return Event;
        }

        public async Task<List<Testimony>> GetAllTestimonies()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("CID", CID);
            var response = await httpClient.GetAsync(GetAllTestimoniesApiUrl);
            HttpContent content = response.Content;
            var json = await content.ReadAsStringAsync();
            var testimonies = JsonConvert.DeserializeObject<List<Testimony>>(json);
            return testimonies;
        }

        public async Task<bool> PostTestimony(Testimony testimony)
        {
            var request = new HttpRequestMessage();
            request.Headers.Add("CID", CID);
            request.RequestUri = new Uri(PostTestimonyUrl);
            request.Method = HttpMethod.Post;

            string json = JsonConvert.SerializeObject(testimony);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            request.Content = content;

            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(request);

            var status = response.IsSuccessStatusCode;
            return status;
        }

        public async Task<List<HomeChurch>> GetAllHomeChurches()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("CID", CID);
            var response = await httpClient.GetAsync(GetAllHomeChurchesUrl);
            HttpContent content = response.Content;
            var json = await content.ReadAsStringAsync();
            var homeChurches = JsonConvert.DeserializeObject<List<HomeChurch>>(json);
            return homeChurches;
        }

        public async Task<List<HomeChurch>> SearchHomeChurches(string name)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("CID", CID);
            var search = SearchHomeChurchUrl + name;
            var response = await httpClient.GetAsync(search);
            HttpContent content = response.Content;
            var json = await content.ReadAsStringAsync();
            var homeChurches = JsonConvert.DeserializeObject<List<HomeChurch>>(json);
            return homeChurches;
        }

        public async Task<List<SeedOfDestiny>> GetSeedOfDestinies()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(GetSeedOfDestinyUrl);
            request.Method = HttpMethod.Post;

            //var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("nscteq-fin", "nsc") });
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("nscteq-fin", "nsc");       
            var content = new FormUrlEncodedContent(parameters);
            request.Content = content;

            var FormattedSeedOfDestinies = new List<SeedOfDestiny>();
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(request);
            HttpContent ResponseContent = response.Content;
            var json = await ResponseContent.ReadAsStringAsync();

            try
            {
                JObject theResponse = JsonConvert.DeserializeObject<dynamic>(json);
                var seedOfDestinies = theResponse.Value<JArray>("rd");

                foreach (var seedOfDestiny in seedOfDestinies)
                {
                    var FormattedSeedOfDestiny = new SeedOfDestiny
                    {
                        date = seedOfDestiny.Value<DateTime>("date"),
                        created = seedOfDestiny.Value<DateTime>("created"),
                        title = Base64Decode(seedOfDestiny.Value<string>("title")),
                        msg = Base64Decode(seedOfDestiny.Value<string>("msg"))
                    };
                    FormattedSeedOfDestinies.Add(FormattedSeedOfDestiny);
                }
            }
            catch (Exception exception)
            {
                return FormattedSeedOfDestinies;

            }

            return FormattedSeedOfDestinies;
        }
    }
}
