using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMonitor.Models.CryptingUp.Assets
{
	[Serializable]
	public class Quote
	{
		[JsonProperty("USD")]
		public MarketChanges USD { get; set; }

		[JsonProperty("EUR")]
		public MarketChanges EUR { get; set; }

		[JsonProperty("AUD")]
		public MarketChanges AUD { get; set; }

		[JsonProperty("NZD")]
		public MarketChanges NZD { get; set; }

		[JsonProperty("JPY")]
		public MarketChanges JPY { get; set; }

		[JsonProperty("GBP")]
		public MarketChanges GBP { get; set; }

		[JsonProperty("CAD")]
		public MarketChanges CAD { get; set; }
	}
}
