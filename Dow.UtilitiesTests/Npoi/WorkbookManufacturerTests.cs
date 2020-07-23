using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dow.Utilities.Npoi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dow.Utilities.Npoi.Input;

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
                CellFormat = CellFormatEnum.Bold | CellFormatEnum.InfoBackground,
                CellValue = "test1"
            });
            input.AddHeadCell(new CreateHeadCellBase(1)
            {
                CellValue = "test2"
            });
            workbookManufacturer.Create("test.xlsx", input);
            Assert.IsTrue(true);
        }
    }
}