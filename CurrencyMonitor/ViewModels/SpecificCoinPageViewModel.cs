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

        #region PageID

        private short _pageID = 2;
        public short PageID
        {
            get => _pageID;
            set => Set(ref _pageID, value);
        }

        #endregion

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

        #region SearchBarText
        private string _searchBarText;
        public string SearchBarText
        {
            get => _searchBarText;
            set => Set(ref _searchBarText, value);
        }
        #endregion

        #region GoBackButtonIsEnable

        private bool _goBackButtonIsEnable = false;
        public bool GoBackButtonIsEnable
        {
            get => _goBackButtonIsEnable;
            set => Set(ref _goBackButtonIsEnable, value);
        }

        #endregion

        #region GoNextButtonIsEnable

        private bool _goNextButtonIsEnable = false;
        public bool GoNextButtonIsEnable
        {
            get => _goNextButtonIsEnable;
            set => Set(ref _goNextButtonIsEnable, value);
        }

        #endregion

        #region Commands

        #region HomeButton
        public ICommand HomeButtonCommand { get; }

        private void OnHomeButtonCommandExecuted(object p)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            App.Current.Windows[0].Close();
        }

        private bool CanHomeButtonCommandExecute(object p) => true;

        #endregion

        #region GoBackButton
        public ICommand GoBackButtonCommand { get; }

        private void OnGoBackButtonCommandExecuted(object p)
        {
            Navigation.GoNextPageIDs.Add(PageID);
            Navigation.SpecificCoinPageNextParameters.Add(_cryptoName);

            int a = Navigation.SpecificCoinPagePreviousParameters.Count;
            Navigation.SpecificCoinPagePreviousParameters.RemoveAt(a - 1);

            int i = Navigation.PreviousPageIDs.Count;
            Navigation.PreviousPageIDs.RemoveAt(i - 1);

            if (Navigation.PreviousPageIDs[i - 2] == 0)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                App.Current.Windows[0].Close();
            }
            else if (Navigation.PreviousPageIDs[i - 2] == 1)
            {
                MoreCryptoPage moreCryptoPage = new MoreCryptoPage();
                moreCryptoPage.Show();
                App.Current.Windows[0].Close();
            }
            else
            {
                SaveParameters.Parameter = p.ToString();

                SpecificCoinPage specificCoinPage = new SpecificCoinPage();
                specificCoinPage.Show();
                App.Current.Windows[0].Close();

            }

        }
        private bool CanGoBackButtonCommandExecute(object p) => true;

        #endregion

        #region GoNextButton

        public ICommand GoNextButtonCommand { get; }

        private void OnGoNextButtonCommandExecuted(object p)
        {
            int nextPageIDsLength = Navigation.GoNextPageIDs.Count;
            Navigation.PreviousPageIDs.Add(Navigation.GoNextPageIDs[nextPageIDsLength - 1]);

            if (Navigation.GoNextPageIDs[nextPageIDsLength - 1] == 0)
            {

                Navigation.GoNextPageIDs.RemoveAt(nextPageIDsLength - 1);

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                App.Current.Windows[0].Close();
            }
            else if (Navigation.GoNextPageIDs[nextPageIDsLength - 1] == 1)
            {
                Navigation.GoNextPageIDs.RemoveAt(nextPageIDsLength - 1);

                MoreCryptoPage moreCryptoPage = new MoreCryptoPage();
                moreCryptoPage.Show();
                App.Current.Windows[0].Close();
            }
            else
            {
                Navigation.GoNextPageIDs.RemoveAt(nextPageIDsLength - 1);

                SaveParameters.Parameter = p.ToString();
                SpecificCoinPage specificCoinPage = new SpecificCoinPage();
                specificCoinPage.Show();
                App.Current.Windows[0].Close();
            }
        }
        private bool CanGoNextButtonCommandExecute(object p) => true;

        #endregion

        #region SearchButton
        public ICommand SearchButtonCommand { get; }

        private void OnSearchButtonCommandExecuted(object p)
        {
            if (!string.IsNullOrEmpty(_searchBarText))
            {
                for (int i = 0; i < _assetsArray.Length; i++)
                {
                    if (_assetsArray[i].AssetName == _searchBarText)
                    {
                        SaveParameters.Parameter = _searchBarText;
                        SpecificCoinPage specificCoinPage = new SpecificCoinPage();
                        specificCoinPage.Show();
                        App.Current.Windows[0].Close();
                    }
                }
                MessageBox.Show("Could not find the coin named: " + _searchBarText);
            }
            else
                MessageBox.Show("Please enter any coin name");

        }

        private bool CanSearchButtonCommandExecute(object p) => true;

        #endregion

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
            _cryptoName = SaveParameters.Parameter;

            if (Navigation.PreviousPageIDs.Count != 0)
                GoBackButtonIsEnable = true;

            if (Navigation.GoNextPageIDs.Count != 0)
                GoNextButtonIsEnable = true;

            if (_cryptoName == "back")
            {
                int i = Navigation.SpecificCoinPagePreviousParameters.Count;
                _cryptoName = Navigation.SpecificCoinPagePreviousParameters[i - 1];
            }
            else if (_cryptoName == "next")
            {
                int b = Navigation.SpecificCoinPageNextParameters.Count;
                _cryptoName = Navigation.SpecificCoinPageNextParameters[b - 1];
                Navigation.SpecificCoinPagePreviousParameters.Add(Navigation.SpecificCoinPageNextParameters[b - 1]);
                Navigation.SpecificCoinPageNextParameters.RemoveAt(b - 1);
            }
            else
            {
                Navigation.PreviousPageIDs.Add(PageID);
                Navigation.SpecificCoinPagePreviousParameters.Add(CryptoName);
            }

            InitializeSpecificCoinPageData();

            #region Commands

            GoNextButtonCommand = new LambdaCommand(OnGoNextButtonCommandExecuted, CanGoNextButtonCommandExecute);
            GoBackButtonCommand = new LambdaCommand(OnGoBackButtonCommandExecuted, CanGoBackButtonCommandExecute);
            HomeButtonCommand = new LambdaCommand(OnHomeButtonCommandExecuted, CanHomeButtonCommandExecute);
            SearchButtonCommand = new LambdaCommand(OnSearchButtonCommandExecuted, CanSearchButtonCommandExecute);
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion
        }
    }
}
