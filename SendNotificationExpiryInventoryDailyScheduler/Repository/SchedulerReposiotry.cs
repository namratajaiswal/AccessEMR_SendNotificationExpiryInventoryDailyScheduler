using Newtonsoft.Json;
using SendNotificationExpiryInventoryDailyScheduler.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SendNotificationExpiryInventoryDailyScheduler.Repository
{
    public class SchedulerReposiotry
    {
        HttpClient client = new HttpClient();
        public SchedulerReposiotry()
        {
            //client.BaseAddress = new Uri("https://accessehealth.com:8080/api/");
            client.BaseAddress = new Uri("https://www.stagingwin.com:9522/api/");
            //client.BaseAddress = new Uri("http://localhost:51269/api/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<JsonModel> PostAsync(CancellationToken cancellationToken)
        {
            NotifyClinicModel data = new NotifyClinicModel();
            var content = JsonConvert.SerializeObject(data);

            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            client.DefaultRequestHeaders.Add("X-AppVersion", "d5e5f369-b515-46d9-949d-ba6ac6f91213");

            HttpResponseMessage response = await client.PostAsync("DailyScheduler/SendNotificationExpiryInventoryDaily", byteContent);
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<JsonModel>(stringResult);
            }
            else
            {
                return new JsonModel { StatusCode = (int)response.StatusCode, Message = "Bad request" };
            }

        }

    }
}
