using System;

namespace Dow.Utilities.Npoi.Input
{
    [Flags]
    public enum CellFormatEnum
    {
        None=0,
        Bold=1,
        /// <summary>
        /// 颜色 #2db7f5
        /// </summary>
        InfoForeColor=1<<1,

        InfoBackground=1<<2,

        /// <summary>
        /// 颜色 #19be6b
        /// </summary>
        SuccessColor = 1 << 3,

        SuccessBackground = 1 << 4,

        /// <summary>
        /// 颜色 #ff9900
        /// </summary>
        WarningColor = 1 << 5,

        WarningBackground = 1 << 6,

        /// <summary>
        /// 颜色 #ed4014
        /// </summary>
        ErrorColor = 1 << 7,

        ErrorBackground = 1 << 8,

    }
}
