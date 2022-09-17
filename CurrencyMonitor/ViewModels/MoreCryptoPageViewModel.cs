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

        public MoreCryptoPageViewModel()
        {
            #region InitializeDataGrid

            Asset[] _cryptoCoinAssets = (CryptingUp.ReceiveAssets().Array);
            for (int i = 0; i < _cryptoCoinAssets.Length; i++)
            {
                if (_cryptoCoinAssets[i].AssetName != String.Empty)
                {
                    DataGridAsset dataGridAsset = new DataGridAsset();
                    dataGridAsset.AssetName = _cryptoCoinAssets[i].AssetName;
                    dataGridAsset.Price = _cryptoCoinAssets[i].Price;
                    dataGridAsset.Volume24h = _cryptoCoinAssets[i].Volume24h;
                    dataGridAsset.Change1h = _cryptoCoinAssets[i].Change1h;
                    dataGridAsset.Change24h = _cryptoCoinAssets[i].Change24h;
                    dataGridAsset.Change7d = _cryptoCoinAssets[i].Change7d;
                    dataGridAsset.MarketCap = _cryptoCoinAssets[i].MarketCap;
                    _dataGridAssets.Add(dataGridAsset);
                }
                else
                    continue;
            }

            #endregion

            #region Commands

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            
            #endregion
        }
    }
}
