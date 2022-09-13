using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMonitor.Models.CryptingUp
{
	[Serializable]
	public class Quote
	{
		[JsonProperty("USD")]
		public Volume USD { get; set; }

		[JsonProperty("EUR")]
		public Volume EUR { get; set; }

		[JsonProperty("AUD")]
		public Volume AUD { get; set; }

		[JsonProperty("NZD")]
		public Volume NZD { get; set; }

		[JsonProperty("JPY")]
		public Volume JPY { get; set; }

		[JsonProperty("GBP")]
		public Volume GBP { get; set; }

		[JsonProperty("CAD")]
		public Volume CAD { get; set; }
	}
}
