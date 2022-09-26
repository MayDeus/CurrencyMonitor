using CurrencyMonitor.Infrastructure.Commands;
using CurrencyMonitor.Models.Additional;
using CurrencyMonitor.Models.CryptingUp;
using CurrencyMonitor.Models.CryptingUp.Assets;
using CurrencyMonitor.Receivers;
using CurrencyMonitor.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CurrencyMonitor.ViewModels
{
    public class CryptoSpecificPageVM : ViewModel
    {

        #region AssetsArray

        private Asset[] _assetsArray;
        public Asset[] AssetsArray
        {
            get => _assetsArray;
            set => Set(ref _assetsArray, value);
        }
        #endregion

        #region CoinData

        private List<Asset> _coinData = new List<Asset>();
        public List<Asset> CoinData
        {
            get => _coinData;
            set => Set(ref _coinData, value);
        }

        #endregion

        private void InitializeCoinData()
        {
            foreach (var item in AssetsArray)
            {
                if (item.AssetName == SaveParameters.Parameter)
                    CoinData.Add(item);
            }
        }

        #region Commands


        #endregion

        public CryptoSpecificPageVM()
        {
                AssetsArray = CryptingUp.ReceiveAssets().Array;
                InitializeCoinData();
        }
    }
}
