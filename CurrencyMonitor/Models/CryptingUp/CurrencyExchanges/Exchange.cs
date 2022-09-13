using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMonitor.Models.CryptingUp
{
	[Serializable]
	public class Exchange
	{
		[JsonProperty("quote")]
		public Quote Quote { get; set; }

		[JsonProperty("exchange_id")]
		public string ExchangeID { get; set; }

		[JsonProperty("name")]
		public string ExchangeName { get; set; }

		[JsonProperty("website")]
		public string WebSite { get; set; }

		[JsonProperty("volume_24h")]
		public decimal Volume24h { get; set; }

	}
}
