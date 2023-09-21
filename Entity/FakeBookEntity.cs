using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiTestAutomation.Entity
{
    public class FakeBookEntity
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("pageCount")]
        public int PageCount { get; set; }

        [JsonPropertyName("Brief")]
        public string? Brief { get; set; }

        [JsonPropertyName("publishDate")]
        public string? PublishDate { get; set; }
    }
}
