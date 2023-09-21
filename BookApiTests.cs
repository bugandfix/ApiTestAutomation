using ApiTestAutomation.Entity;
using ApiTestAutomation.Infra.Requests;
using FluentAssertions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiTestAutomation;

public class BookApiTests
{
    BookRequests request = new BookRequests();

    [Test]
    public void ListofAllBooks()
    {
        //var baseUrl = "https://localhost:7216/api/Books";
        //RestClient client = new RestClient(baseUrl);
        //RestRequest restRequest = new RestRequest(baseUrl, Method.Get);
        //RestResponse restResponse = client.Execute(restRequest, Method.Get);


        //restResponse.Should().NotBeNull();
        ////restResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        //restResponse.StatusCode.Should().Be(HttpStatusCode.OK);


        RestResponse response = request.GetFakeApiRequest();
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public void CreateABook()
    {
        RestResponse response = request.PostFakeApiRequest();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var bodyContent = JsonSerializer.Deserialize<FakeBookEntity>(response.Content);
        bodyContent.Id.Should().NotBeNull();
        bodyContent.Description.Should().NotBeNull();
        bodyContent.Title.Should().NotBeNull();
    }

    [Test]
    public void UpdateABook()
    {
        RestResponse response = request.PutFakeApiRequest(15);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var bodyContent = JsonSerializer.Deserialize<FakeBookEntity>(response.Content!);
        bodyContent!.Id.Should().NotBeNull();
        bodyContent!.Id.Should().Be(15);
        bodyContent!.Description.Should().NotBeNull();
        bodyContent!.Title.Should().NotBeNull();
    }

    [Test]
    public void DeleteABook()
    {
        RestResponse response = request.DeleteFakeApiRequest(5);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
    }


}

