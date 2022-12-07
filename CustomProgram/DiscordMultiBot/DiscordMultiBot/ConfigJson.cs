using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiscordMultiBot
{
    public struct ConfigJson
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
        [JsonProperty("ytapi")]
        public string Ytapi { get; private set; }
        [JsonProperty("sql")]
        public string Sql { get; private set; }
    }
}
