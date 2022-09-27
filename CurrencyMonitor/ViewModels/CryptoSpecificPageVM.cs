using CurrencyMonitor.Infrastructure.Commands;
using CurrencyMonitor.Models.Additional;
using CurrencyMonitor.Models.CryptingUp;
using CurrencyMonitor.Models.CryptingUp.Assets;
using CurrencyMonitor.Receivers;
using CurrencyMonitor.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CurrencyMonitor.ViewModels
{
    public class CryptoSpecificPageVM : ViewModel
    {

        private Asset[] _assetsArray;
        public Asset[] AssetsArray
        {
            get => _assetsArray;
            set => Set(ref _assetsArray, value);
        }

        private Asset _coinData;
        public Asset CoinData
        {
            get => _coinData;
            set => Set(ref _coinData, value);
        }

        private void InitializeCoinData()
        {
            CoinData = AssetsArray.FirstOrDefault(item => item.AssetName == SaveParameters.Parameter);
            if (CoinData != null)
            {
                CoinData.Change1h = Math.Round(CoinData.Change1h, 4);
                CoinData.Change24h = Math.Round(CoinData.Change24h, 4);
                CoinData.Change7d = Math.Round(CoinData.Change7d, 4);
                CoinData.Volume24h = Math.Round(CoinData.Volume24h, 4);
                CoinData.Price = Math.Round(CoinData.Price, 4);
                CoinData.TotalSupply = Math.Round(CoinData.TotalSupply, 4);
                CoinData.CirculatingSupply = Math.Round(CoinData.CirculatingSupply, 4);
                CoinData.MaxSupply = Math.Round(CoinData.MaxSupply, 4);
                CoinData.MarketCap = Math.Round(CoinData.MarketCap, 4);
            }
        }

        public CryptoSpecificPageVM()
        {
            AssetsArray = CryptingUp.ReceiveAssets().Result.Array;
            InitializeCoinData();
        }
    }
}
