using ApiTestAutomation.Entity;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestAutomation.Infra.Requests
{
    public class BookRequests
    {
        static readonly string baseUrl = "https://localhost:7216/api/Books";





        public static FakeBookEntity BuildBodyRequest(int? id = null)
        {
            return new FakeBookEntity
            {
                Id = id ?? 100,
                Title = "Test Book",
                Description = "Mussum Ipsum, cacilds vidis litro abertis.  Quem num gosta di mim que vai caçá sua turmis!",
                Brief = "uem num gosta di mim que vai caçá sua turmis!",
                PageCount = 100,
                PublishDate = "2023-09-03T13:50:32.6884665+00:00"
            };
        }

        public RestResponse PostFakeApiRequest()
        {
            RestClient client = new RestClient(baseUrl);
            var body = BuildBodyRequest();
            RestRequest restRequest = new RestRequest(baseUrl, Method.Post);
            restRequest.AddBody(body, ContentType.Json);

            RestResponse restResponse = client.Execute(restRequest, Method.Post);

            return restResponse;
        }


        public RestResponse PutFakeApiRequest(int id)
        {
            RestClient client = new RestClient(baseUrl);
            var body = BuildBodyRequest(id);
            RestRequest restRequest = new RestRequest($"{baseUrl}/{id}", Method.Put);
            restRequest.AddBody(body, ContentType.Json);

            RestResponse restResponse = client.Execute(restRequest, Method.Put);

            return restResponse;
        }


        public RestResponse DeleteFakeApiRequest(int id)
        {
            RestClient client = new RestClient(baseUrl);
            var body = BuildBodyRequest(id);
            RestRequest restRequest = new RestRequest($"{baseUrl}/{id}", Method.Delete);
            restRequest.AddBody(body, ContentType.Json);
            RestResponse restResponse = client.Execute(restRequest, Method.Delete);

            return restResponse;
        }



        public RestResponse GetFakeApiRequest()
        {
            RestClient client = new RestClient(baseUrl);
            RestRequest restRequest = new RestRequest(baseUrl, Method.Get);
            RestResponse restResponse = client.Execute(restRequest, Method.Get);
            return restResponse;
        }


    }
}
