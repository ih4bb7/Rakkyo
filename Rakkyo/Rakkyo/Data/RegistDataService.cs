using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Rakkyo.Data
{
    public class RegistDataService
    {
        public static void Regist(RegistData registData, double evaluation, string reviews)
        {
            var fileInfo = new FileInfo("../Rakkyo/DB/�f�[�^�x�[�X.xlsx");
            var excelDriverCore = new ExcelDriverCore(fileInfo);
            var tenpoSheetName = "�X��";
            var tenpoLastRow = excelDriverCore.GetLastRow(tenpoSheetName);
            registData.ShopCD = tenpoLastRow;

            // �]����������
            var hyoukaSheetName = "�]��";
            var hyoukaLastRow = excelDriverCore.GetLastRow(hyoukaSheetName);
            excelDriverCore.IntWriting(hyoukaSheetName, "A" + (hyoukaLastRow + 1), registData.ShopCD);
            excelDriverCore.DoubleWriting(hyoukaSheetName, "B" + (hyoukaLastRow + 1), evaluation);

            // ���R�~��������
            var kutikomiSheetName = "���R�~";
            var kutikomiLastRow = excelDriverCore.GetLastRow(kutikomiSheetName);
            excelDriverCore.IntWriting(kutikomiSheetName, "A" + (kutikomiLastRow + 1), registData.ShopCD);
            excelDriverCore.Writing(kutikomiSheetName, "B" + (kutikomiLastRow + 1), reviews);

            // ���C����񏑂�����
            excelDriverCore.IntWriting(tenpoSheetName, "A" + (tenpoLastRow + 1), registData.ShopCD);
            excelDriverCore.Writing(tenpoSheetName, "B" + (tenpoLastRow + 1), registData.ShopName);
            excelDriverCore.FormulaWriting(tenpoSheetName, "C" + (tenpoLastRow + 1), "=SUMIFS(�]��!$B$2:$B$200,�]��!$A$2:$A$200,A" + (tenpoLastRow + 1) + ")/COUNTIFS(�]��!$A$2:$A$200,A" + (tenpoLastRow + 1) + ")");
            excelDriverCore.SetNumberFormat(tenpoSheetName, "C" + (tenpoLastRow + 1), "0.00");
            excelDriverCore.Writing(tenpoSheetName, "D" + (tenpoLastRow + 1), registData.Genre);
            excelDriverCore.Writing(tenpoSheetName, "E" + (tenpoLastRow + 1), registData.Place);
            excelDriverCore.Writing(tenpoSheetName, "F" + (tenpoLastRow + 1), registData.URL);
            excelDriverCore.Writing(tenpoSheetName, "G" + (tenpoLastRow + 1), registData.CanUseCash.ToString());
            excelDriverCore.Writing(tenpoSheetName, "H" + (tenpoLastRow + 1), registData.CanUseCard.ToString());
            excelDriverCore.Writing(tenpoSheetName, "I" + (tenpoLastRow + 1), registData.CanUseEM.ToString());
            excelDriverCore.Writing(tenpoSheetName, "J" + (tenpoLastRow + 1), registData.CanUseQR.ToString());
            excelDriverCore.Writing(tenpoSheetName, "K" + (tenpoLastRow + 1), registData.UpdateDatetime.ToString("yyyy/MM/dd"));
            excelDriverCore.Dispose();
        }
    }
}
