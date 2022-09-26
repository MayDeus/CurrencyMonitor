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
    public class WindowViewModel : ViewModel
    {

        private Page MainPage;
        private Page LoadMorePage;
        private Page CryptoSpecificPage;

        #region AssetsArray

        private Asset[] _assetsArray;
        public Asset[] AssetsArray
        {
            get => _assetsArray;
            set => Set(ref _assetsArray, value);
        }
        #endregion

        #region CurrentPage

        private Page _currentPage;
        public Page CurrentPage
        {
            get => _currentPage;
            set => Set(ref _currentPage, value);
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

        #region LoadMorePageBtn

        public ICommand LoadMorePageBtnCommand { get; }

        private void OnLoadMorePageBtnCommandExecuted(object p)
        {
            CurrentPage = LoadMorePage;
        }
        private bool CanLoadMorePageBtnCommandExecute(object p) => true;

        #endregion

        #region MainPageBtn

        public ICommand MainPageBtnCommand { get; }

        private void OnMainPageBtnCommandExecuted(object p)
        {
            CurrentPage = MainPage;
        }
        private bool CanMainPageBtnCommandExecute(object p) => true;

        #endregion

        #region CryptoSpecificPageBtn

        public ICommand CryptoSpecificPageBtnCommand { get; }

        private void OnCryptoSpecificPageBtnCommandExecuted(object p)
        {
            CurrentPage = CryptoSpecificPage;
        }
        private bool CanCryptoSpecificPageBtnCommandExecute(object p) => true;

        #endregion

        #region SearchBtnClick

        public ICommand SearchBtnClickCommand { get; }

        private void OnSearchBtnClickCommandExecuted(object p)
        {
            if (String.IsNullOrEmpty(SearchBarText))
                MessageBox.Show("Please enter any coin name");
            else if (SearchBarText == SaveParameters.Parameter)
                CurrentPage = CryptoSpecificPage;
            else
            {
                foreach (var item in AssetsArray)
                {
                    if (item.AssetName == SearchBarText)
                    {
                        SaveParameters.Parameter = item.AssetName;
                        CryptoSpecificPage = new CryptoSpecificPage();
                        CurrentPage = CryptoSpecificPage;
                        break;
                    }
                    else if (item == AssetsArray[AssetsArray.Length - 1])
                        MessageBox.Show("Couldn't find a coin named: " + SearchBarText);
                }
            }
        }
        private bool CanSearchBtnClickCommandExecute(object p) => true;

        #endregion


        #endregion

        public WindowViewModel()
        {
            AssetsArray = CryptingUp.ReceiveAssets().Array;

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
