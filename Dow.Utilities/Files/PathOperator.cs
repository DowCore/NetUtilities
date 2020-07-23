using System.IO;

namespace Dow.Utilities.Files
{
    public static class PathOperator
    {
        public static string GetSuffix(string filePath)
        {
            return Path.GetExtension(filePath).Replace(".", "");
        }
    }
}
