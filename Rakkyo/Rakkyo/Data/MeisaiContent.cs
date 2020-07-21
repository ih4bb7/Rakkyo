using System;
using System.Collections.Generic;

namespace Rakkyo.Data
{
    public class MeisaiContent
    {
        /// <summary>
        /// �X��CD
        /// </summary>
        public int TenpoCD { get; set; }
        /// <summary>
        /// �X�ܖ�
        /// </summary>
        public string TenpoName { get; set; }
        /// <summary>
        /// �W������
        /// </summary>
        public string Genre { get; set; }
        /// <summary>
        /// �ꏊ
        /// </summary>
        public string Place { get; set; }
        /// <summary>
        /// �]��
        /// </summary>
        public double Evaluation { get; set; }
        /// <summary>
        /// �x�����@
        /// </summary>
        public string MethodOfPayment { get; set; }
        /// <summary>
        /// �։��i��
        /// </summary>
        public string Smoking { get; set; }
        /// <summary>
        /// URL
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// ���R�~
        /// </summary>
        public List<string> Reviews { get; set; }
    }
}
