using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pract12_trpo.Classes.Validations
{
    public class PassValidation : ValidationRule
    {
        public static bool CheckUpper(string inputString)
        {
            bool result = false;
            foreach (char c in inputString)
            {
                if (char.IsUpper(c))
                {
                    result = true;
                    break;
                }
            }
            return result;

        }
        public static bool CheckLower(string inputString)
        {
            bool result = false;
            foreach (char c in inputString)
            {
                if (char.IsLower(c))
                {
                    result = true;
                    break;
                }
            }
            return result;

        }
        public static bool CheckDigits(string inputString)
        {
            bool result = false;
            foreach (char c in inputString)
            {
                if (char.IsDigit(c))
                {
                    result = true;
                    break;
                }
            }
            return result;

        }
        public static bool CheckLetters(string inputString)
        {
            bool result = false;
            foreach (char c in inputString)
            {
                if (char.IsLetter(c))
                {
                    result = true;
                    break;
                }
            }
            return result;

        }

        public static bool CheckIncludes(string inputString)
        {

            if (!CheckLetters(inputString)) return false;
            if (!CheckDigits(inputString)) return false;
            if (!CheckUpper(inputString)) return false;
            if (!CheckLower(inputString)) return false;

            return true;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            var inputString = value.ToString();

            if (value == null)
            {
                return new ValidationResult(false, "Значение не может быть пустым");
            }
            if (inputString.Length < 8)
            {
                return new ValidationResult(false, $"Пароль должен содержать минимум 8 символов");
            }
            if (inputString.Length > 255)
            {
                return new ValidationResult(false, $"Пароль не должен содержать больше чем 255 символов");
            }
            if (!CheckIncludes(inputString))
            {
                return new ValidationResult(false, $"Пароль обязательно должен включать: символы, цифры, буквы в верхнем и нижнем регистре");
            }
            return ValidationResult.ValidResult;
        }
    }
}
