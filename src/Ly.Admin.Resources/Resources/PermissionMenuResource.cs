using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Admin.Resources
{
    public class PermissionMenuResource
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "path", NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "component", NullValueHandling = NullValueHandling.Ignore)]
        public string Component { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "meta", NullValueHandling = NullValueHandling.Ignore)]
        public VueRouterMetaResource Meta { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "alias", NullValueHandling = NullValueHandling.Ignore)]
        public string Alias { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "redirect", NullValueHandling = NullValueHandling.Ignore)]
        public string Redirect { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "caseSensitive", NullValueHandling = NullValueHandling.Ignore)]
        public string CaseSensitive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "children", NullValueHandling = NullValueHandling.Ignore)]
        public List<PermissionMenuResource> Children { get; set; }
    }
}
