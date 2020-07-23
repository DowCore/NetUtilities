using Dow.Utilities.Npoi.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Dow.Utilities.Npoi.Tests
{
    [TestClass()]
    public class WorkbookManufacturerTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            var workbookManufacturer = new WorkbookManufacturer();
            var input = new CreateSheetInput();
            input.AddHeadCell(new CreateHeadCellBase(0)
            {
                CellFormat = EnumCellFormat.Bold | EnumCellFormat.InfoBackground,
                CellValue = "test1"
            });
            input.AddHeadCell(new CreateHeadCellBase(1)
            {
                CellValue = "test2"
            });

            input.AddHeadCell(new DropdownColumn(2)
            {
                CellValue = "test3",
                DropdownList = new List<string> { "LIST1", "LIST2" }
            });
            workbookManufacturer.Create("test.xlsx", input);
            Assert.IsTrue(true);
        }
    }
}