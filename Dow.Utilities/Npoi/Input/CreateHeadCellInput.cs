using NPOI.HPSF;
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

        public CreateHeadCellBase(int column, ExcelCellTypeEnum excelCellTypeEnum):this(column)
        {
            CellType = (CellType)excelCellTypeEnum;
        }
        /*end 构造函数块*/

        /*start 变量与属性块*/
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

        /*end 变量与属性块*/
    }

    public class DropdownColumn : CreateHeadCellBase
    {
        public DropdownColumn(int column):base(column)
        {

        }

        public List<string> DropdownList { get; set; }

        public ValidationErrorMessage ErrorMessage { get; set; }

        public virtual void SetColumnDropdown(ICell cell)
        {
            var dataValidationHelp = cell.Sheet.GetDataValidationHelper();
            var addressList = new CellRangeAddressList(1, 65535, ColumnIndex, ColumnIndex);
            var constraint = dataValidationHelp.CreateExplicitListConstraint(DropdownList.ToArray());
            var dataValidation = dataValidationHelp.CreateValidation(constraint, addressList);
            if(ErrorMessage!=null)
            {
                dataValidation.CreateErrorBox(ErrorMessage.Title,ErrorMessage.Context);
                dataValidation.ShowErrorBox = true;
            }
            cell.Sheet.AddValidationData(dataValidation);
        }
    }
}
