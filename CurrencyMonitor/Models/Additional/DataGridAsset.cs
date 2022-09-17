using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMonitor.Models.Additional
{
    public class DataGridAsset
    {
        public string AssetName { get; set; }
        public decimal Price { get; set; }
        public decimal Volume24h { get; set; }
        public decimal Change1h { get; set; }
        public decimal Change24h { get; set; }
        public decimal Change7d { get; set; }
        public decimal MarketCap { get; set; }

    }
}
