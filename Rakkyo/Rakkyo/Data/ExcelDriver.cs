using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Rakkyo.Data
{
    public class ExcelDriver
    {
        public Results ReadExcel(string path)
        {
            var fileInfo = new FileInfo(path);
            var excel = new ExcelDriverCore(fileInfo);

            return results;
        }
        private Results ExecuteCore(ExcelDriverCore writeExcel, Parent parent)
        {
            var count = 0;
            try
            {
                foreach (var process in parent.Processes)
                {
                    count++;

                    // 処理をどんどん増やしていく
                    if (process.Shori == null)
                    {
                        continue;
                    }
                    if (process.Shori == ConstValue.WRITING)
                    {
                        writeExcel.Writing(process.Arg1, process.Arg2, process.Arg3);
                        continue;
                    }
                    if (process.Shori == ConstValue.NUMBERWRITING)
                    {
                        writeExcel.NumberWriting(process.Arg1, process.Arg2, int.Parse(process.Arg3));
                        continue;
                    }
                    if (process.Shori == ConstValue.FORMULAWRITING)
                    {
                        writeExcel.FormulaWriting(process.Arg1, process.Arg2, process.Arg3);
                        continue;
                    }
                    if (process.Shori == ConstValue.RANGECOPY_AND_PASTE)
                    {
                        var value = readExcel.RangeCopy(process.Arg1, process.Arg2);
                        writeExcel.RangePaste(process.Arg3, process.Arg4, value);
                        continue;
                    }
                    // 処理をどんどん増やしていく
                }
            }
            catch (Exception e)
            {
                return new Results() { HasError = true, Message = ConstValue.PROCESSING_CONTENT + count + "：" + e.Message };
            }
            finally
            {
                readExcel.Dispose();
                writeExcel.Dispose();
            }

            return new Results() { Message = ConstValue.SUCCESS };
        }
    }
}