using CurrencyMonitor.Models.CryptingUp;
using CurrencyMonitor.Models.CryptingUp.Assets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyMonitor.Receivers
{
	public static class CryptingUp
	{
		private static readonly Uri ASSETS_URI = new Uri("https://cryptingup.com/api/assets");
		private static readonly Uri EXCHANGES_ALL_URI = new Uri("https://cryptingup.com/api/exchanges");
		private static readonly Uri EXCHANGES_SPECIFIC_URI = new Uri("https://cryptingup.com/api/exchanges/{0}");

		public static async Task<Exchanges> ReceiveExchanges()
		{
			HttpClient client = new HttpClient();
			string data = string.Empty;

			try
			{
				HttpResponseMessage response = await client.GetAsync(EXCHANGES_ALL_URI).ConfigureAwait(false);
				data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
			}
			catch
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

		public static async Task<Assets> ReceiveAssets()
		{
			HttpClient client = new HttpClient();
			string data = string.Empty;

			try
			{
				HttpResponseMessage response = await client.GetAsync(ASSETS_URI).ConfigureAwait(false);
				data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
			}
			catch
			{
				// in case request has gone wrong
				return null;
			}

			var result = ParseAssets(data);
			return result;
		}

		private static Assets ParseAssets(string jsonString)
		{
			return JsonConvert.DeserializeObject<Assets>(jsonString);
		}

	}
}
