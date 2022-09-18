using CurrencyMonitor.Infrastructure.Commands;
using CurrencyMonitor.Models.Additional;
using CurrencyMonitor.Models.CryptingUp.Assets;
using CurrencyMonitor.Receivers;
using CurrencyMonitor.Stores;
using CurrencyMonitor.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CurrencyMonitor.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {

        #region PageID

        private short _pageID = 0;
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

        #region TopCryptoCoinsDisplay
        private string _cryptoCoin1;
        public string CryptoCoin1
        {
            get => _cryptoCoin1;
            set => Set(ref _cryptoCoin1, value);
        }

        private string _cryptoCoin2;
        public string CryptoCoin2
        {
            get => _cryptoCoin2;
            set => Set(ref _cryptoCoin2, value);
        }

        private string _cryptoCoin3;
        public string CryptoCoin3
        {
            get => _cryptoCoin3;
            set => Set(ref _cryptoCoin3, value);
        }

        private string _cryptoCoin4;
        public string CryptoCoin4
        {
            get => _cryptoCoin4;
            set => Set(ref _cryptoCoin4, value);
        }

        private string _cryptoCoin5;
        public string CryptoCoin5
        {
            get => _cryptoCoin5;
            set => Set(ref _cryptoCoin5, value);
        }

        private string _cryptoCoin6;
        public string CryptoCoin6
        {
            get => _cryptoCoin6;
            set => Set(ref _cryptoCoin6, value);
        }

        private string _cryptoCoin7;
        public string CryptoCoin7
        {
            get => _cryptoCoin7;
            set => Set(ref _cryptoCoin7, value);
        }

        private string _cryptoCoin8;
        public string CryptoCoin8
        {
            get => _cryptoCoin8;
            set => Set(ref _cryptoCoin8, value);
        }

        private string _cryptoCoin9;
        public string CryptoCoin9
        {
            get => _cryptoCoin9;
            set => Set(ref _cryptoCoin9, value);
        }

        private string _cryptoCoin10;
        public string CryptoCoin10
        {
            get => _cryptoCoin10;
            set => Set(ref _cryptoCoin10, value);
        }

        private string _cryptoCoin11;
        public string CryptoCoin11
        {
            get => _cryptoCoin11;
            set => Set(ref _cryptoCoin11, value);
        }

        private string _cryptoCoin12;
        public string CryptoCoin12
        {
            get => _cryptoCoin12;
            set => Set(ref _cryptoCoin12, value);
        }

        private string _cryptoCoin13;
        public string CryptoCoin13
        {
            get => _cryptoCoin13;
            set => Set(ref _cryptoCoin13, value);
        }

        private string _cryptoCoin14;
        public string CryptoCoin14
        {
            get => _cryptoCoin14;
            set => Set(ref _cryptoCoin14, value);
        }

        private string _cryptoCoin15;
        public string CryptoCoin15
        {
            get => _cryptoCoin15;
            set => Set(ref _cryptoCoin15, value);
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

        #region Navigation

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

            int i = Navigation.PreviousPageIDs.Count;

            if (Navigation.PreviousPageIDs[i - 1] == 0)
            {
                Navigation.PreviousPageIDs.RemoveAt(i - 1);

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                App.Current.Windows[0].Close();
            }
            else if (Navigation.PreviousPageIDs[i - 1] == 1)
            {
                Navigation.PreviousPageIDs.RemoveAt(i - 1);
                MoreCryptoPage moreCryptoPage = new MoreCryptoPage();
                moreCryptoPage.Show();
                App.Current.Windows[0].Close();
            }
            else
            {
                Navigation.PreviousPageIDs.RemoveAt(i - 1);
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

        #endregion

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

        #region OpenSpecificCryptoPageCommand
        public ICommand OpenSpecificCryptoPageCommand { get; }

        private void OnOpenSpecificCryptoPageCommandExecuted(object p)
        {
            SaveParameters.Parameter = p.ToString();
            SpecificCoinPage specificCoinPage = new SpecificCoinPage();
            specificCoinPage.Show();
            App.Current.Windows[0].Close();

        }
        private bool CanOpenSpecificCryptoPageCommandExecute(object p) => true;

        #endregion

        #region OpenMoreCryptoPageCommand
        public ICommand OpenMoreCryptoPageCommand { get; }

        private void OnOpenMoreCryptoPageCommandExecuted(object p)
        {
            MoreCryptoPage moreCryptoPage = new MoreCryptoPage();
            moreCryptoPage.Show();
            App.Current.Windows[0].Close();

        }
        private bool CanOpenMoreCryptoPageCommandExecute(object p) => true;
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            _assetsArray = (CryptingUp.ReceiveAssets().Array);

            if (Navigation.PreviousPageIDs.Count > 2)
                GoBackButtonIsEnable = true;

            if (Navigation.GoNextPageIDs.Count != 0)
                GoNextButtonIsEnable = true;

            Navigation.PreviousPageIDs.Add(PageID);

            #region InitializeCryptoCoinButtons
            _cryptoCoin1 = _assetsArray[0].AssetName;
            _cryptoCoin2 = _assetsArray[1].AssetName;
            _cryptoCoin3 = _assetsArray[2].AssetName;
            _cryptoCoin4 = _assetsArray[3].AssetName;
            _cryptoCoin5 = _assetsArray[4].AssetName;
            _cryptoCoin6 = _assetsArray[5].AssetName;
            _cryptoCoin7 = _assetsArray[6].AssetName;
            _cryptoCoin8 = _assetsArray[7].AssetName;
            _cryptoCoin9 = _assetsArray[8].AssetName;
            _cryptoCoin10 = _assetsArray[9].AssetName;
            _cryptoCoin11 = _assetsArray[10].AssetName;
            _cryptoCoin12 = _assetsArray[11].AssetName;
            _cryptoCoin13 = _assetsArray[12].AssetName;
            _cryptoCoin14 = _assetsArray[13].AssetName;
            _cryptoCoin15 = _assetsArray[15].AssetName;
            #endregion

            #region Commands
            GoBackButtonCommand = new LambdaCommand(OnGoBackButtonCommandExecuted, CanGoBackButtonCommandExecute);
            GoNextButtonCommand = new LambdaCommand(OnGoNextButtonCommandExecuted, CanGoNextButtonCommandExecute);
            HomeButtonCommand = new LambdaCommand(OnHomeButtonCommandExecuted, CanHomeButtonCommandExecute);
            SearchButtonCommand = new LambdaCommand(OnSearchButtonCommandExecuted, CanSearchButtonCommandExecute);
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            OpenSpecificCryptoPageCommand = new LambdaCommand(OnOpenSpecificCryptoPageCommandExecuted, CanOpenSpecificCryptoPageCommandExecute);
            OpenMoreCryptoPageCommand = new LambdaCommand(OnOpenMoreCryptoPageCommandExecuted, CanOpenMoreCryptoPageCommandExecute);

            #endregion
        }
    }
}
