using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dow.Utilities.Npoi.Input;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

namespace Dow.Utilities.Npoi.Tests
{
    [TestClass()]
    public class WorkbookFactoryTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            var workbookFactory = new WorkbookFactory();
            var xssfWorkbook = workbookFactory.Create(ExcelTypeEnum.XLSX);
            var hssfWorkbook = workbookFactory.Create(ExcelTypeEnum.XLS);
            Assert.IsTrue(xssfWorkbook is XSSFWorkbook,"excel文件类型不对");
            Assert.IsTrue(hssfWorkbook is HSSFWorkbook, "excel文件类型不对");
        }
    }
}