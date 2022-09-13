using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMonitor.Models.CryptingUp.Assets
{
	[Serializable]
	public class MarketChanges
	{
		[JsonProperty("price")]
		public decimal Price { get; set; }

		[JsonProperty("volume_24h")]
		public decimal V24h { get; set; }

		[JsonProperty("market_cap")]
		public decimal MarketCap { get; set; }

		[JsonProperty("fully_diluted_market_cap")]
		public decimal FullyDilutedMarketCap { get; set; }
	}
}
