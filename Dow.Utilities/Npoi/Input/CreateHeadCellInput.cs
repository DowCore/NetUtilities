using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.Collections.Generic;

namespace Dow.Utilities.Npoi.Input
{
    public class CreateHeadCellBase:IHeadCell
    {
        /*start 构造函数块*/
        public CreateHeadCellBase(int column)
        {
            ColumnIndex = column;
        }

        public CreateHeadCellBase(int column, CellType cellType):this(column)
        {
            CellType = cellType;
        }

        public CreateHeadCellBase(int column, EnumExcelCellType excelCellTypeEnum):this(column)
        {
            CellType = (CellType)excelCellTypeEnum;
        }
        /*end 构造函数块*/
        /*start 公共方法 */
        public void AddFormat(ICellFormat action)
        {
            Actions.Add(action);
        }

        public virtual void ExecuteFormat(ICell cell)
        {
            Font = cell.Sheet.Workbook.CreateFont();
            CellStyle = cell.Sheet.Workbook.CreateCellStyle();
            Actions.ForEach(t =>
            {
                t.Format(cell,this);
            });
            var style = cell.Sheet.Workbook.CreateCellStyle();
            var format = cell.Sheet.Workbook.CreateDataFormat();
            style.DataFormat = format.GetFormat(ColumnDadaFormat);
            cell.Sheet.SetDefaultColumnStyle(ColumnIndex, style);
        }

        /*end 公共方法*/
        /*start 变量与属性块*/

        public IFont Font { get; private set; }

        public ICellStyle CellStyle { get; private set; }
        public int FontSize { get; set; } = 10;
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
        public int ColumnIndex { get; private set; }
        /// <summary>
        /// 单元格格式
        /// </summary>
        public CellType CellType { get; private set; } = CellType.String;

        public string ColumnDadaFormat { get; set; } = ExcelCloumnDataFormat.General;

        private EnumCellFormat cellFormat;
        public EnumCellFormat CellFormat { get => cellFormat; set { cellFormat = value; AddFormatRange(); } }

        public List<ICellFormat> Actions { get; private set; } = new List<ICellFormat>();
        /*end 变量与属性块*/

        private void AddFormatRange()
        {
          
            if ((CellFormat & EnumCellFormat.Bold) == EnumCellFormat.Bold)
            {
                AddFormat(new BoldweightFormat());
            }

            if ((CellFormat & EnumCellFormat.InfoColor) == EnumCellFormat.InfoColor)
            {
                AddFormat(new InfoColorFormat());
            }

            if((CellFormat & EnumCellFormat.InfoBackground) == EnumCellFormat.InfoBackground)
            {
                AddFormat(new InfoBackgroundFormat());
            }
        }
    }

    public class DropdownColumn : CreateHeadCellBase
    {
        public DropdownColumn(int column):base(column)
        {

        }

        public List<string> DropdownList { get; set; }

        public ValidationErrorMessage ErrorMessage { get; set; }
        public override void ExecuteFormat(ICell cell)
        {
            base.ExecuteFormat(cell);
            SetColumnDropdown(cell);
        }

        private  void SetColumnDropdown(ICell cell)
        {
            var dataValidationHelp = cell.Sheet.GetDataValidationHelper();
            var addressList = new CellRangeAddressList(1, 65535, ColumnIndex, ColumnIndex);
            var constraint = dataValidationHelp.CreateExplicitListConstraint(DropdownList.ToArray());
            var dataValidation = dataValidationHelp.CreateValidation(constraint, addressList);
            if (ErrorMessage != null)
            {
                dataValidation.CreateErrorBox(ErrorMessage.Title, ErrorMessage.Context);
                dataValidation.ShowErrorBox = true;
            }
            cell.Sheet.AddValidationData(dataValidation);
        }
    }
}
