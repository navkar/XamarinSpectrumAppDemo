using System;
using Newtonsoft.Json;

namespace SpectrumApp.Data
{
    public class CategoryModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}

