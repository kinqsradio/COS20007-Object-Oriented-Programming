using System;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace DiscordMultiBot
{
	public class Readjson
	{
		#region Variables

		private string _json;

		#endregion

		#region Constructor

		public Readjson(string jsonProperty)
		{
			_json = jsonProperty;
		}

		#endregion

		#region Method

		public string Json
		{
			get => _json;
		}

		public string ReadFromJson()
		{
			var json = string.Empty;
			using (var fs = File.OpenRead("config.json"))
			using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
				json = sr.ReadToEnd();
			var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);
			switch (Json)
			{
				case "token":
					return configJson.Token;
				case "ytapi":
					return configJson.Ytapi;
                case "sql":
                    return configJson.Sql;
                default:
					return "Not Found.";
			}
		}
		#endregion
	}
}

