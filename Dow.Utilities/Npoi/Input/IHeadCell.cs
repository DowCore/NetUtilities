using NPOI.SS.UserModel;

namespace Dow.Utilities.Npoi.Input
{
    public interface IHeadCell
    {
        IFont Font { get; }

        ICellStyle CellStyle { get; }
    }
}
