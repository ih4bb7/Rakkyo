using System;

namespace Rakkyo.Data
{
    public class RegistData
    {
        public int ShopCD { get; set; }
        public string ShopName { get; set; }
        public string Genre { get; set; }
        public string URL { get; set; }
        public string Place { get; set; }
        public bool CanUseCash { get; set; }
        public bool CanUseCard { get; set; }
        public bool CanUseEM { get; set; }
        public bool CanUseQR { get; set; }
        public DateTime UpdateDatetime { get; set; }
    }
}
