using Dow.Utilities.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Dow.Utilities.Npoi.Input
{
    public  class CreateSheetInput
    {
        public CreateSheetInput()
        {
            SheetName = "sheet1";
        }
        public CreateSheetInput(string sheetName):this()
        {
            SheetName = sheetName;
        }
        public string SheetName { get; private set; }
        /// <summary>
        /// 第一行的高度 *10
        /// </summary>
        public int HeadRowHeight { get; set; } = 2;

        

        public List<CreateHeadCellBase> HeadCells { get; private set; } = new List<CreateHeadCellBase>();

        public void AddHeadCell(CreateHeadCellBase createHeadCellBase)
        {
            if(createHeadCellBase.ColumnIndex<0)
            {
                throw new UserDefinedException(ErrorMessageCode.CannotBeLessThanZero);
            }
            if(HeadCells.Any(t=>t.ColumnIndex== createHeadCellBase.ColumnIndex))
            {
                throw new UserDefinedException(ErrorMessageCode.DuplicateColumnsIndex);
            }
            HeadCells.Add(createHeadCellBase);
        }
    }
}
