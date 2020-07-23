using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dow.Utilities.Npoi.Input;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;

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
            first.CreateSheet();
            Assert.IsTrue(t==t1,"单例失效");
            Assert.IsTrue(first is XSSFWorkbook, "不是xlsx类型");
            Assert.IsTrue(second is HSSFWorkbook, "不是xls类型");
        }

        [TestMethod()]
        public void TestConstruction()
        {
            var input = new CreateSheetInput("123");
            var head = new CreateHeadCellBase(1, EnumExcelCellType.Boolean);
            var t = Singleton.SingletonBase<WorkbookFactory>.Instance.Singleton;
            var first = t.Create(ExcelTypeEnum.XLSX);
            var sheet = first.CreateSheet();
            var row = sheet.CreateRow(0);
            var style = first.CreateCellStyle();
            var format = first.CreateDataFormat();
            style.DataFormat=format.GetFormat("0");
            sheet.SetDefaultColumnStyle(0, style);
            FileStream sw = File.Create("test.xlsx");
            first.Write(sw);
            Assert.IsTrue(input.SheetName == "123", "构造链不是想象的");
        }
        [TestMethod()]
        public void TestReadExcel()
        {
            var wookbook = new XSSFWorkbook("test.xlsx");
            var sheet = wookbook.GetSheetAt(0);
            var style1 = sheet.GetColumnStyle(0);
            Assert.IsTrue(true);
        }

    }
}