using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Rakkyo.Data
{
    public class RakkyoCore
    {
        public Task<List<Shop>> GetShopList()
        {
            var fileInfo = new FileInfo("../Rakkyo/DB/�f�[�^�x�[�X.xlsx");
            var excelDriverCore = new ExcelDriverCore(fileInfo);
            var lastRow = excelDriverCore.GetLastRow("�X��");
            var value = excelDriverCore.GetValueForAddress("�X��", "A2:B" + lastRow);

            var shop = new Shop();
            var shopList = new List<Shop>();
            var foreachCount = 0;

            foreach (var item in (object[,])value)
            {
                if (foreachCount % 2 == 0)
                {
                    shop.ShopCD = int.Parse(item.ToString());
                    foreachCount++;
                    continue;
                }
                shop.ShopName = item.ToString();
                shopList.Add(shop);
                shop = new Shop();
                foreachCount++;
            }

            value = excelDriverCore.GetValueForAddress("�����]��", "A2:B" + lastRow);
            foreachCount = 0;
            var listCount = 0;

            foreach (var item in (object[,])value)
            {
                if (foreachCount % 2 == 0)
                {
                    foreachCount++;
                    continue;
                }
                shopList[listCount].ComprehensiveEvaluation = Math.Round(double.Parse(item.ToString()), 2);
                listCount++;
                foreachCount++;
            }

            excelDriverCore.Dispose();
            return Task.FromResult(shopList);
        }
    }
}
