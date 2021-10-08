using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ly.Admin.Resources
{
    public class PermissionMenuResource
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("openType")]
        public string OpenType { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("children")]
        public List<PermissionMenuResource> Children { get; set; }

    }
}