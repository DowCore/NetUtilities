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
            var t = Singleton.SingletonBase<WorkbookFactory>.Instance.Singleton;
            var t1 = Singleton.SingletonBase<WorkbookFactory>.Instance.Singleton;
            var first=t.Create(ExcelTypeEnum.XLSX);
            var second = t1.Create(ExcelTypeEnum.XLS);
            Assert.IsTrue(t==t1,"单例失效");
            Assert.IsTrue(first is XSSFWorkbook, "不是xlsx类型");
            Assert.IsTrue(second is HSSFWorkbook, "不是xls类型");
        }
    }
}