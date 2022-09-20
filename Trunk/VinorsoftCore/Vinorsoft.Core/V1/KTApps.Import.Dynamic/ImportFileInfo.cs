using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KTApps.Import.Dynamic
{
    public class ColumnInfo
    {
        public string HeaderName { set; get; }
        public string ExcelCellAddress { set; get; }
    }

    public class ImportFileInfo
    {
        public ImportFileInfo()
        {
            Columns = new List<ColumnInfo>();
        }
        public int TotalRow { set; get; }
        public int TotalColumn { set; get; }
        public IList<ColumnInfo> Columns { set; get; }

        public void LoadImportFile(Stream stream)
        {
            using (var package = new ExcelPackage())
            {
                    package.Load(stream);
                    var ws = package.Workbook.Worksheets[0];
                    TotalRow = ws.Dimension.Rows;
                    TotalColumn = ws.Dimension.Columns;
                    Columns.Clear();

                    for (int index = 1; index <= TotalRow; index++)
                    {
                        for (int colIndex = 0; colIndex < TotalColumn; colIndex++)
                        {
                            Columns.Add(new ColumnInfo()
                            {
                                ExcelCellAddress = ws.Cells[index, colIndex].Address,
                                HeaderName = ws.Cells[index, colIndex].GetValue<string>()
                            });
                        }
                    }
            }
        }

        public void LoadImportFile(byte[] file)
        {
            using (var package = new ExcelPackage())
            {
                using (Stream stream = new MemoryStream(file))
                {
                    package.Load(stream);
                    var ws = package.Workbook.Worksheets[0];
                    TotalRow = ws.Dimension.Rows;
                    TotalColumn = ws.Dimension.Columns;
                    Columns.Clear();

                    for (int index = 1; index <= TotalRow; index++)
                    {
                        for (int colIndex = 0; colIndex < TotalColumn; colIndex++)
                        {
                            Columns.Add(new ColumnInfo()
                            {
                                ExcelCellAddress = ws.Cells[index, colIndex].Address,
                                HeaderName = ws.Cells[index, colIndex].GetValue<string>()
                            });
                        }
                    }
                }
            }
        }
    }
}
