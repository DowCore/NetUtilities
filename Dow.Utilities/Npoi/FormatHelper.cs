using Dow.Utilities.Npoi.Input;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Dow.Utilities.Npoi
{
    public static class FormatHelper
    {
        public static void BackgroundFormat(ICell cell, IHeadCell headCell, byte[] rgb)
        {
            if (cell.Sheet.Workbook is HSSFWorkbook)
            {
                HSSFPalette palette = (cell.Sheet.Workbook as HSSFWorkbook).GetCustomPalette();
                palette.SetColorAtIndex(HSSFColor.Black.Index, rgb[0], rgb[1], rgb[2]);
                var style = headCell.CellStyle as HSSFCellStyle;
                style.FillForegroundColor = HSSFColor.Black.Index;
                style.FillPattern = FillPattern.SolidForeground;
                cell.CellStyle = style;
            }
            else
            {
                var style = (headCell.CellStyle as XSSFCellStyle);
                style.SetFillForegroundColor(new XSSFColor(rgb));
                style.FillPattern = FillPattern.SolidForeground;
            }
        }
    }
}
