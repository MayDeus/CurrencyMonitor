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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CurrencyMonitor.ViewModels
{
    public class WindowViewModel : ViewModel
    {

        private Page MainPage;
        private Page LoadMorePage;
        private Page CryptoSpecificPage;


        private Asset[] _assetsArray;
        public Asset[] AssetsArray
        {
            get => _assetsArray;
            set => Set(ref _assetsArray, value);
        }


        private Page _currentPage;
        public Page CurrentPage
        {
            get => _currentPage;
            set => Set(ref _currentPage, value);
        }


        private string _searchBarText;
        public string SearchBarText
        {
            get => _searchBarText;
            set => Set(ref _searchBarText, value);
        }

        #region Commands

        public ICommand LoadMorePageBtnCommand { get; }

        private void OnLoadMorePageBtnCommandExecuted(object p)
        {
            CurrentPage = LoadMorePage;
        }
        private bool CanLoadMorePageBtnCommandExecute(object p) => true;


        public ICommand MainPageBtnCommand { get; }

        private void OnMainPageBtnCommandExecuted(object p)
        {
            CurrentPage = MainPage;
        }
        private bool CanMainPageBtnCommandExecute(object p) => true;


        public ICommand CryptoSpecificPageBtnCommand { get; }

        private void OnCryptoSpecificPageBtnCommandExecuted(object p)
        {
            CurrentPage = CryptoSpecificPage;
        }
        private bool CanCryptoSpecificPageBtnCommandExecute(object p) => true;


        public ICommand SearchBtnClickCommand { get; }

        private void OnSearchBtnClickCommandExecuted(object p)
        {
            if (string.IsNullOrEmpty(SearchBarText))
                MessageBox.Show("Please enter any coin name");
            else if (SearchBarText == SaveParameters.Parameter)
                CurrentPage = CryptoSpecificPage;
            else
            {
                var asset = AssetsArray.FirstOrDefault(a => a.AssetName == SearchBarText);

                if (asset == null)
                {
                    MessageBox.Show("Couldn't find a coin named: " + SearchBarText);
                    return;
                }

                SaveParameters.Parameter = asset.AssetName;
                CryptoSpecificPage = new CryptoSpecificPage();
                CurrentPage = CryptoSpecificPage;
            }
        }

        private bool CanSearchBtnClickCommandExecute(object p) => true;


        #endregion

        public WindowViewModel()
        {
            AssetsArray = CryptingUp.ReceiveAssets().Result.Array;

            MainPage = new Views.Pages.MainPage();
            LoadMorePage = new LoadMorePage();
            CryptoSpecificPage = new CryptoSpecificPage();

            CurrentPage = MainPage;

            #region Commands

            MainPageBtnCommand = new LambdaCommand(OnMainPageBtnCommandExecuted, CanMainPageBtnCommandExecute);
            LoadMorePageBtnCommand = new LambdaCommand(OnLoadMorePageBtnCommandExecuted, CanLoadMorePageBtnCommandExecute);
            CryptoSpecificPageBtnCommand = new LambdaCommand(OnCryptoSpecificPageBtnCommandExecuted, CanCryptoSpecificPageBtnCommandExecute);
            SearchBtnClickCommand = new LambdaCommand(OnSearchBtnClickCommandExecuted, CanSearchBtnClickCommandExecute);

            #endregion

        }
    }
}
