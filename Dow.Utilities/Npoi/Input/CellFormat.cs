using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;

namespace Dow.Utilities.Npoi.Input
{
    [Flags]
    public enum CellFormatEnum
    {
        None=0,
        Bold=1,
        /// <summary>
        /// 颜色 #2db7f5
        /// </summary>
        InfoForeColor=1<<1,

        InfoBackground=1<<2,

        /// <summary>
        /// 颜色 #19be6b
        /// </summary>
        SuccessColor = 1 << 3,

        SuccessBackground = 1 << 4,

        /// <summary>
        /// 颜色 #ff9900
        /// </summary>
        WarningColor = 1 << 5,

        WarningBackground = 1 << 6,

        /// <summary>
        /// 颜色 #ed4014
        /// </summary>
        ErrorColor = 1 << 7,

        ErrorBackground = 1 << 8,

    }


    public interface ICellFormat
    {
        void Format(ICell cell, IHeadCell headCell);
    }
    public class BoldweightFormat: ICellFormat
    {
        public void Format(ICell cell, IHeadCell headCell)
        {
            var font = headCell.Font;
            font.Boldweight = (short)FontBoldWeight.Bold;
            headCell.CellStyle.SetFont(font);
            cell.CellStyle = headCell.CellStyle;
        }
    }
    public class InfoForeColorFormat:ICellFormat
    {
        public void Format(ICell cell, IHeadCell headCell)
        {
            var font = headCell.Font;
            if (font is XSSFFont)
            {
                (font as XSSFFont).SetColor(new XSSFColor(new byte[] { 45, 183, 245 }));
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
        public void Format(ICell cell, IHeadCell headCell)
        {
            if(cell.Sheet.Workbook is HSSFWorkbook)
            {
                byte[] rgb = new byte[] { 45, 183, 245 };
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
                style.SetFillForegroundColor(new XSSFColor(new byte[] { 45, 183, 245 }));
                style.FillPattern= FillPattern.SolidForeground;
            }
        }
    }
    public class CellFormatAction
    {
       

        public static void SetInfoForeColor(ICell cell)
        {
            //int[] rgb = new int[] { 45, 183, 245 };
            //HSSFPalette palette = (cell.Sheet.Workbook as HSSFWorkbook).GetCustomPalette();
            //palette.SetColorAtIndex(HSSFColor.Black.Index, (byte)rgb[0], (byte)rgb[1], (byte)rgb[2]);
            //var style = headCell.CellStyle as HSSFCellStyle;
            //style.FillForegroundColor = HSSFColor.Black.Index;
            //style.FillPattern = FillPattern.SolidForeground;
            //cell.CellStyle = style;

        }
    }
}
