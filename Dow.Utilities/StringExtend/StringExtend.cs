using Dow.Utilities.Regulars;
using System;
using System.Text.RegularExpressions;

namespace Dow.Utilities.StringExtend
{
    public static class StringExtend
    {
        /// <summary>
        /// 字符串是整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInteger(this string str)
        {
            return Regex.IsMatch(str, RegularCommon.IntegerRegular);
        }
        /// <summary>
        /// 验证字符串是否由正负号（+-）、数字、小数点构成，并且最多只有一个小数点
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string str)
        {
            Regex regex = new Regex(RegularCommon.NumericRegular);
            return regex.IsMatch(str);
        }

        /// <summary>
        /// 验证字符串是否只包含数字与字母
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumericOrLetters(this string str)
        {
            return Regex.IsMatch(str, RegularCommon.NumericOrLetterRegular);
        }

        /// <summary>
        ///  两个字符串内容比较，去掉空白
        /// </summary>
        /// <param name="str"></param>
        /// <param name="equalString"></param>
        /// <returns></returns>
        public static bool ContentEquals(this string str, string equalString)
        {
            return str?.Trim().Equals(equalString?.Trim()) ?? false;
        }

        /// <summary>
        /// 两个字符串内容比较，去掉空白
        /// </summary>
        /// <param name="str"></param>
        /// <param name="equalString"></param>
        /// <param name="stringComparison"></param>
        /// <returns></returns>
        public static bool ContentEquals(this string str, string equalString, StringComparison stringComparison)
        {
            return str?.Trim().Equals(equalString?.Trim(), stringComparison) ?? false;
        }
    }
}
