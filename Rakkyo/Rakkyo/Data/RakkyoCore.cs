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
            var fileInfo = new FileInfo("../Rakkyo/DB/ÉfÅ[É^ÉxÅ[ÉX.xlsx");
            var excelDriverCore = new ExcelDriverCore(fileInfo);
            var lastRow = excelDriverCore.GetLastRow("ìXï‹");
            var value = excelDriverCore.GetValueForAddress("ìXï‹", "A2:E" + lastRow);

            var shop = new Shop();
            var shopList = new List<Shop>();
            var count = 0;

            foreach (var item in (object[,])value)
            {
                if (count % 5 == 0)
                {
                    shop.ShopCD = int.Parse(item.ToString());
                    count++;
                    continue;
                }
                else if (count % 5 == 1)
                {
                    shop.ShopName = item.ToString();
                    count++;
                    continue;
                }
                else if (count % 5 == 2)
                {
                    shop.ComprehensiveEvaluation = Math.Round(double.Parse(item.ToString()), 2);
                    count++;
                    continue;
                }
                else if (count % 5 == 3)
                {
                    shop.Genre = item.ToString();
                    count++;
                    continue;
                }

                shop.Place = item.ToString();
                shopList.Add(shop);
                shop = new Shop();
                count++;
            }

            //value = excelDriverCore.GetValueForAddress("ëççáï]âø", "A2:B" + lastRow);
            //foreachCount = 0;
            //var listCount = 0;

            //foreach (var item in (object[,])value)
            //{
            //    if (foreachCount % 2 == 0)
            //    {
            //        foreachCount++;
            //        continue;
            //    }
            //    shopList[listCount].ComprehensiveEvaluation = Math.Round(double.Parse(item.ToString()), 2);
            //    listCount++;
            //    foreachCount++;
            //}

            excelDriverCore.Dispose();
            return Task.FromResult(shopList);
        }
    }
}
