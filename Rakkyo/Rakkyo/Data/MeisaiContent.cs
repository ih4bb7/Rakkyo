using System;
using System.Collections.Generic;

namespace Rakkyo.Data
{
    public class MeisaiContent
    {
        /// <summary>
        /// XÜCD
        /// </summary>
        public int TenpoCD { get; set; }
        /// <summary>
        /// XÜ¼
        /// </summary>
        public string TenpoName { get; set; }
        /// <summary>
        /// W
        /// </summary>
        public string Genre { get; set; }
        /// <summary>
        /// ê
        /// </summary>
        public string Place { get; set; }
        /// <summary>
        /// ]¿
        /// </summary>
        public double Evaluation { get; set; }
        /// <summary>
        /// x¥û@
        /// </summary>
        public string MethodOfPayment { get; set; }
        /// <summary>
        /// Öi
        /// </summary>
        public string Smoking { get; set; }
        /// <summary>
        /// URL
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// ûR~
        /// </summary>
        public List<string> Reviews { get; set; }
    }
}
