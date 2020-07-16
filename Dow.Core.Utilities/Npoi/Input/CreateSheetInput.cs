namespace Dow.Core.Utilities.Npoi.Input
{
    public  class CreateSheetInput
    {
        public CreateSheetInput()
        {
            SheetName = "sheet1";
        }
        public CreateSheetInput(string sheetName)
        {
            SheetName = sheetName;
        }
        public string SheetName { get; private set; }
        /// <summary>
        /// 第一行的高度 *10
        /// </summary>
        public int HeadRowHeight { get; set; } = 2;
    }
}
