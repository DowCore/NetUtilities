using Dow.Utilities.Colors;
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
    public class InfoColorFormat:ICellFormat
    {
        readonly static byte[] RGB = DesignColor.InfoRGB;
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

    public class SuccessColorFormat : ICellFormat
    {
        readonly static byte[] RGB = DesignColor.SuccessRGB;
        public void Format(ICell cell, IHeadCell headCell)
        {
            var font = headCell.Font;
            if (font is XSSFFont)
            {
                (font as XSSFFont).SetColor(new XSSFColor(RGB));
            }
            else
            {
                font.Color = HSSFColor.LightGreen.Index;
            }
            headCell.CellStyle.SetFont(font);
            cell.CellStyle = headCell.CellStyle;
        }
    }
    public class InfoBackgroundFormat : ICellFormat
    {
        readonly static byte[] RGB = DesignColor.InfoRGB;
        public void Format(ICell cell, IHeadCell headCell)
        {
            FormatHelper.BackgroundFormat(cell, headCell, RGB);
        }
    }


    public class SuccessBackgroundFormat : ICellFormat
    {
        readonly static byte[] RGB = DesignColor.SuccessRGB;
        public void Format(ICell cell, IHeadCell headCell)
        {
            FormatHelper.BackgroundFormat(cell, headCell, RGB);
        }
    }
   
}
