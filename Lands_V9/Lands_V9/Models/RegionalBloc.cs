using System;
using System.Collections.Generic;
using System.Text;

namespace Lands_V9.Models
{
    using Newtonsoft.Json;

    class RegionalBloc
    {
        [JsonProperty(PropertyName = "acronym")]
        public string Acronym { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
