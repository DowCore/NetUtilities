using Dow.Core.Utilities.Npoi.Input;
using Dow.Core.Utilities.Singleton;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Dow.Core.Utilities.Npoi
{
    public interface  IWorkbookFactory
    {
         IWorkbook Create(ExcelTypeEnum excelTypeEnum);
    }

    public partial class WorkbookFactory : IWorkbookFactory,ISingleton
    {
        public virtual IWorkbook Create(ExcelTypeEnum excelTypeEnum)
        {
            if(excelTypeEnum== ExcelTypeEnum.XLS)
            {
                return new HSSFWorkbook();
            }
            return new XSSFWorkbook();
        }
    }
}
