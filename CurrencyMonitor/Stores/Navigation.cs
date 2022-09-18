using CurrencyMonitor.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMonitor.Stores
{
    public static class Navigation
    {

        public static List<string> SpecificCoinPagePreviousParameters = new List<string>();

        public static List<string> SpecificCoinPageNextParameters = new List<string>();

        public static List<short> PreviousPageIDs = new List<short>();

        public static List<short> GoNextPageIDs = new List<short>();

    }
}
