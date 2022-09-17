using CurrencyMonitor.Infrastructure.Commands;
using CurrencyMonitor.Models.Additional;
using CurrencyMonitor.Models.CryptingUp.Assets;
using CurrencyMonitor.Receivers;
using CurrencyMonitor.Stores;
using CurrencyMonitor.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CurrencyMonitor.ViewModels
{
    public class SpecificCoinPageViewModel : ViewModel
    {
        #region Title
        private string _Title = "CurrencyMonitor";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion

        #region AssetArray

        private Asset[] _assetsArray;
        public Asset[] AssetsArray
        {
            get => _assetsArray;
            set => Set(ref _assetsArray, value);
        }

        #endregion

        #region SpecificCoinPageData

        private string _cryptoName = "Name";
        public string CryptoName
        {
            get => _cryptoName;
            set => Set(ref _cryptoName, value);
        }

        private decimal _cryptoPrice;
        public decimal CryptoPrice
        {
            get => _cryptoPrice;
            set => Set(ref _cryptoPrice, value);
        }

        private decimal _cryptoChange1h;
        public decimal CryptoChange1h
        {
            get => _cryptoChange1h;
            set => Set(ref _cryptoChange1h, value);
        }

        private decimal _cryptoChange24h;
        public decimal CryptoChange24h
        {
            get => _cryptoChange24h;
            set => Set(ref _cryptoChange24h, value);
        }

        private decimal _cryptoChange7d;
        public decimal CryptoChange7d
        {
            get => _cryptoChange7d;
            set => Set(ref _cryptoChange7d, value);
        }

        private decimal _cryptoVolume24h;
        public decimal CryptoVolume24h
        {
            get => _cryptoVolume24h;
            set => Set(ref _cryptoVolume24h, value);
        }

        private decimal _cryptoMarketCup;
        public decimal CryptoMarketCup
        {
            get => _cryptoMarketCup;
            set => Set(ref _cryptoMarketCup, value);
        }

        private decimal _cryptoFullyDilutedMarketCap;
        public decimal CryptoFullyDilutedMarketCap
        {
            get => _cryptoFullyDilutedMarketCap;
            set => Set(ref _cryptoFullyDilutedMarketCap, value);
        }

        private decimal _cryptoCirculatingSupply;
        public decimal CryptoCirculatingSupply
        {
            get => _cryptoCirculatingSupply;
            set => Set(ref _cryptoCirculatingSupply, value);
        }

        private decimal _cryptoTotalSupply;
        public decimal CryptoTotalSupply
        {
            get => _cryptoTotalSupply;
            set => Set(ref _cryptoTotalSupply, value);
        }

        private decimal _cryptoMaxSupply;
        public decimal CryptoMaxSupply
        {
            get => _cryptoMaxSupply;
            set => Set(ref _cryptoMaxSupply, value);
        }

        private string _cryptoDescription;
        public string CryptoDescription
        {
            get => _cryptoDescription;
            set => Set(ref _cryptoDescription, value);
        }

        #endregion

        #region InitializeSpecificCoinPageDataMethod
        private void InitializeSpecificCoinPageData()
        {
            for (int i = 0; i < _assetsArray.Length; i++)
            {
                if (_assetsArray[i].AssetName == _cryptoName)
                {
                    _cryptoPrice = _assetsArray[i].Price;
                    _cryptoChange1h = _assetsArray[i].Change1h;
                    _cryptoChange24h = _assetsArray[i].Change24h;
                    _cryptoChange7d = _assetsArray[i].Change7d;
                    _cryptoVolume24h = _assetsArray[i].Volume24h;
                    _cryptoMarketCup = _assetsArray[i].MarketCap;
                    _cryptoFullyDilutedMarketCap = _assetsArray[i].FullyDilutedMarketCap;
                    _cryptoCirculatingSupply = _assetsArray[i].CirculatingSupply;
                    _cryptoTotalSupply = _assetsArray[i].TotalSupply;
                    _cryptoMaxSupply = _assetsArray[i].MaxSupply;
                    _cryptoDescription = _assetsArray[i].AssetDescription;
                }
            }
        }
        #endregion

        #region Commands

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        private bool CanCloseApplicationCommandExecute(object p) => true;

        #endregion


        #endregion

        public SpecificCoinPageViewModel()
        {
            _assetsArray = (CryptingUp.ReceiveAssets().Array);
            _cryptoName = SaveParameter.Parameter;

            InitializeSpecificCoinPageData();

            #region Commands

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion
        }
    }
}
