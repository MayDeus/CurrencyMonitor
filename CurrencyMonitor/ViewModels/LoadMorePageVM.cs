using CurrencyMonitor.Infrastructure.Commands;
using CurrencyMonitor.Models.Additional;
using CurrencyMonitor.Models.CryptingUp;
using CurrencyMonitor.Models.CryptingUp.Assets;
using CurrencyMonitor.Receivers;
using CurrencyMonitor.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CurrencyMonitor.ViewModels
{
    public class LoadMorePageVM : ViewModel
    {

        #region AssetsArray

        private Asset[] _assetsArray;
        public Asset[] AssetsArray
        {
            get => _assetsArray;
            set => Set(ref _assetsArray, value);
        }
        #endregion

        #region Commands


        #endregion

        public LoadMorePageVM()
        {
            AssetsArray = CryptingUp.ReceiveAssets().Array;
        }
    }
}
