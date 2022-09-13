using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMonitor.Models.CryptingUp
{
	[Serializable]
	public class Volume
	{
		[JsonProperty("volume_24h")]
		public decimal V24h { get; set; }
	}
}
