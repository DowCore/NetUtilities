namespace Dow.Utilities.Npoi.Input
{
    public interface IHeadCell
    {
    }

    public class HeadCellBase:IHeadCell
    {
        /// <summary>
        /// 默认单元格宽度的倍数，即 * 256
        /// </summary>
        public int Width { get; set; } = 10;
        /// <summary>
        /// 单元格内容
        /// </summary>
        public string CellValue { get; set; }
        /// <summary>
        /// 列对应的位置，A=0,，B=1，依次类推
        /// </summary>
        public int ColumnIndex { get; set; }
    }
}
