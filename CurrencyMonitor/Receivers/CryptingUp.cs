using CurrencyMonitor.Models.CryptingUp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CurrencyMonitor.Receivers
{
	public static class CryptingUp
	{
		private static readonly Uri ASSETS_URI = new Uri("https://cryptingup.com/api/assets");
		// https://cryptingup.com/api/assets/<ID>
		private static readonly Uri EXCHANGES_ALL_URI = new Uri("https://cryptingup.com/api/exchanges");
		private static readonly Uri EXCHANGES_SPECIFIC_URI = new Uri("https://cryptingup.com/api/exchanges/{0}");

		public static Exchanges ReceiveExchanges()
		{
			WebClient wc = new WebClient();
			wc.Encoding = Encoding.UTF8;

			string data;

			try
			{
				data = wc.DownloadString(EXCHANGES_ALL_URI);
			}
			catch (WebException)
			{
				// in case request has gone wrong
				return null;
			}
			
			var result = ParseExchanges(data);
			return result;
		}

		private static Exchanges ParseExchanges(string jsonString)
		{
			return JsonConvert.DeserializeObject<Exchanges>(jsonString);
		}

	}
}
