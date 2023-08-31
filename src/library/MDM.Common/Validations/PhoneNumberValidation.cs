using System.Text.RegularExpressions;

namespace MDM.Common.Validations
{
    public static class PhoneNumberValidation
    {
        public const string motif = @"^[0][0-9]{9}";

        public static bool IsPhoneNbr(string number)
        {
            if (number != null)
                return Regex.IsMatch(number, motif);
            else
                return false;
        }
    }
}
