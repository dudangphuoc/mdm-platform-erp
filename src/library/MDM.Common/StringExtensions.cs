using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDM.Common;
public static class StringExtensions
{
    private static readonly string[] VietNamChar = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

    /// <summary>
    ///     Convert string in vietnamese to vietnamese without sign
    ///     example: "Trường đại học" => "Truong dai hoc"
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string ToNoneSignVietnamese(this string text)
    {
        try
        {
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                {
                    text = text.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
                }
            }

            return text;
        }
        catch
        {
            return string.Empty;
        }
    }

    /// <summary>
    ///     Convert string in vietnamese to vietnamese without sign
    ///     example: "Trường đại học" => "TRUONG DAI HOC"
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string ToNoneSignVietnameseNormalized(this string text)
    {
        try
        {
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                {
                    text = text.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
                }
            }

            return text.ToUpperInvariant();
        }
        catch
        {
            return string.Empty;
        }
    }

}