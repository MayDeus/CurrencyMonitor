using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMonitor.Models.CryptingUp.Assets
{
	[Serializable]
	public class Assets
	{
		[JsonProperty("assets")]
		public Asset[] Array { get; set; }

	}
}
