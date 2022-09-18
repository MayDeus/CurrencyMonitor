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
    public class MoreCryptoPageViewModel : ViewModel
    {

        #region PageID

        private short _pageID = 1;
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

        #region CryptoCoinAssets

        private ObservableCollection<DataGridAsset> _dataGridAssets = new ObservableCollection<DataGridAsset>();
        public ObservableCollection<DataGridAsset> DataGridAssets
        {
            get => _dataGridAssets;
            set => Set(ref _dataGridAssets, value);
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

            int i = Navigation.PreviousPageIDs.Count;
            Navigation.PreviousPageIDs.RemoveAt(i - 1);

            if (Navigation.PreviousPageIDs[i - 2] == 0)
            {
                Navigation.PreviousPageIDs.RemoveAt(i - 2);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                App.Current.Windows[0].Close();
            }
            else if (Navigation.PreviousPageIDs[i - 2] == 1)
            {
                Navigation.PreviousPageIDs.RemoveAt(i - 2);
                MoreCryptoPage moreCryptoPage = new MoreCryptoPage();
                moreCryptoPage.Show();
                App.Current.Windows[0].Close();
            }
            else
            {
                SaveParameters.Parameter = p.ToString();
                Navigation.PreviousPageIDs.RemoveAt(i - 2);
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

        public MoreCryptoPageViewModel()
        {
            _assetsArray = (CryptingUp.ReceiveAssets().Array);

            if (Navigation.PreviousPageIDs.Count != 0)
                GoBackButtonIsEnable = true;

            if (Navigation.GoNextPageIDs.Count != 0)
                GoNextButtonIsEnable = true;

            Navigation.PreviousPageIDs.Add(PageID);

            #region InitializeDataGrid

            for (int i = 0; i < _assetsArray.Length; i++)
            {
                if (_assetsArray[i].AssetName != String.Empty)
                {
                    DataGridAsset dataGridAsset = new DataGridAsset();
                    dataGridAsset.AssetName = _assetsArray[i].AssetName;
                    dataGridAsset.Price = _assetsArray[i].Price;
                    dataGridAsset.Volume24h = _assetsArray[i].Volume24h;
                    dataGridAsset.Change1h = _assetsArray[i].Change1h;
                    dataGridAsset.Change24h = _assetsArray[i].Change24h;
                    dataGridAsset.Change7d = _assetsArray[i].Change7d;
                    dataGridAsset.MarketCap = _assetsArray[i].MarketCap;
                    _dataGridAssets.Add(dataGridAsset);
                }
                else
                    continue;
            }

            #endregion

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
