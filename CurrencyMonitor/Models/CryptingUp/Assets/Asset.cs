using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMonitor.Models.CryptingUp.Assets
{
	[Serializable]
	public class Asset
	{
		[JsonProperty("quote")]
		public Quote Quote { get; set; }

		[JsonProperty("asset_id")]
		public string AssetID { get; set; }

		[JsonProperty("name")]
		public string AssetName { get; set; }

		[JsonProperty("description")]
		public string AssetDescription { get; set; }

		[JsonProperty("website")]
		public string WebSite { get; set; }

		[JsonProperty("ethereum_contract_address")]
		public string EthereumContractAdress { get; set; }

		[JsonProperty("pegged")]
		public string Pegged { get; set; }

		[JsonProperty("price")]
		public decimal Price { get; set; }

		[JsonProperty("volume_24h")]
		public decimal Volume24h { get; set; }

		[JsonProperty("change_1h")]
		public decimal Change1h { get; set; }

		[JsonProperty("change_24h")]
		public decimal Change24h { get; set; }

		[JsonProperty("change_7d")]
		public decimal Change7d { get; set; }

		[JsonProperty("total_supply")]
		public decimal TotalSupply { get; set; }

		[JsonProperty("circulating_supply")]
		public decimal CirculatingSupply { get; set; }

		[JsonProperty("max_supply")]
		public decimal MaxSupply { get; set; }

		[JsonProperty("market_cap")]
		public decimal MarketCap { get; set; }

		[JsonProperty("fully_diluted_market_cap")]
		public decimal FullyDilutedMarketCap { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("created_at")]
		public string CreatedAt { get; set; }

		[JsonProperty("updated_at")]
		public string UpdatedAt { get; set; }

	}
}
