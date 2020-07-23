using Dow.Utilities.Npoi.Input;
using Dow.Utilities.Singleton;
using NPOI.SS.UserModel;
using System.Collections.Generic;
using System.IO;

namespace Dow.Utilities.Npoi
{
    public class WorkbookManufacturer: ISingleton
    {
        public IWorkbookFactory WorkbookFactory { get => SingletonBase<WorkbookFactory>.Instance.Singleton; }
        public void Create(string filePath, CreateSheetInput createSheetInput)
        {
            var suffix = Path.GetExtension(filePath);
            var workbook = WorkbookFactory.Create(GetExcelType(suffix));
            CreteSheet(workbook, createSheetInput);
            FileStream sw = File.Create(filePath);
            workbook.Write(sw);
        }

        public void Create(string filePath, List<CreateSheetInput> createSheetInputs)
        {
            var suffix = Path.GetExtension(filePath);
            var workbook = WorkbookFactory.Create(GetExcelType(suffix));
            createSheetInputs.ForEach(item =>
            {
                CreteSheet(workbook, item);
            });
            FileStream sw = File.Create(filePath);
            workbook.Write(sw);
        }
        public ExcelTypeEnum GetExcelType(string suffix)
        {
            switch(suffix.ToLower())
            {
                case ".xlsx":
                    return ExcelTypeEnum.XLSX;
                case ".xls":
                    return ExcelTypeEnum.XLS;
                default:
                    return ExcelTypeEnum.XLSX;
            }
        }
        private void CreteSheet(IWorkbook workbook, CreateSheetInput createSheetInput)
        {
            var sheet = workbook.CreateSheet(createSheetInput.SheetName);
            var row = sheet.CreateRow(0);
            createSheetInput.HeadCells.ForEach(item =>
            {
                var cell = row.CreateCell(item.ColumnIndex,item.CellType);
                cell.SetCellValue(item.CellValue);
                item.ExecuteFormat(cell);
            });
        }
    }
}
