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

        #region Commands

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

            SearchButtonCommand = new LambdaCommand(OnSearchButtonCommandExecuted, CanSearchButtonCommandExecute);
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            
            #endregion
        }
    }
}
