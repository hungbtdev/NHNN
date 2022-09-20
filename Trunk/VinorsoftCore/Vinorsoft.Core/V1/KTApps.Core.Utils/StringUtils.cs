using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace KTApps.Core.Utils
{
    public class StringUtils
    {
        public string RemoveUnicode3(string s)
        {
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }

        public static string RemoveUnicode(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public static string ReplaceSpecialChar(string value)
        {
            value = RemoveUnicode(value);
            return Regex.Replace(value, @"[^0-9a-zA-Z]+", "_");
        }

        public static string ReplaceByProp(string replaceText, object data, string propName)
        {
            if (data == null)
            {
                throw new ArgumentException("data is null");
            }
            var value = data.GetPropValue(propName);
            return replaceText.Replace("{" + propName + "}", string.Format("{0}", value));
        }

        public static bool IsNumeric(object Expression)
        {
            bool isNum = double.TryParse(Convert.ToString(Expression), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out double retNum);
            return isNum;
        }

        public static bool IsDate(object Expression, string format)
        {
            bool isValid = DateTime.TryParseExact(Convert.ToString(Expression),
                                     format,
                                     CultureInfo.InvariantCulture,
                                     DateTimeStyles.None,
                                     out DateTime dt);
            return isValid;
        }
    }

}
