using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Dow.Utilities.Npoi.Input
{


    public interface ICellFormat
    {
        void Format(ICell cell, IHeadCell headCell);
    }
    public class BoldweightFormat: ICellFormat
    {
        public void Format(ICell cell, IHeadCell headCell)
        {
            var font = headCell.Font;
            font.IsBold = true;
            headCell.CellStyle.SetFont(font);
            cell.CellStyle = headCell.CellStyle;
        }
    }
    public class InfoForeColorFormat:ICellFormat
    {
        readonly static byte[] RGB = new byte[] { 45, 183, 245 };
        public void Format(ICell cell, IHeadCell headCell)
        {
            var font = headCell.Font;
            if (font is XSSFFont)
            {
                (font as XSSFFont).SetColor(new XSSFColor(RGB));
            }
            else
            {
               font.Color = HSSFColor.LightBlue.Index;
            }
            headCell.CellStyle.SetFont(font);
            cell.CellStyle = headCell.CellStyle;
        }
    }

    public class InfoBackgroundFormat : ICellFormat
    {
        readonly static byte[] RGB = new byte[] { 45, 183, 245 };
        public void Format(ICell cell, IHeadCell headCell)
        {
            FormatHelper.BackgroundFormat(cell, headCell, RGB);
        }
    }

    public static class FormatHelper
    {
        public static void  BackgroundFormat(ICell cell, IHeadCell headCell, byte[] rgb)
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
