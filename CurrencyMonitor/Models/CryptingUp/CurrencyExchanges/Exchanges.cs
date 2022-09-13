using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMonitor.Models.CryptingUp
{
	[Serializable]
	public class Exchanges
	{
		[JsonProperty("exchanges")]
		public Exchange[] Array { get; set; } 

	}
}
