using pract12_trpo.Data.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pract12_trpo.Classes.Validations
{
    class GroupNameValidation : ValidationRule
    {
        public static bool IsUnique(string inputString)
        {
            InterestGroupService service = new InterestGroupService();
            foreach (InterestGroup group in service.InterestGroups)
            {
                if (group.Title.ToLower() == inputString.ToLower())
                    return false;
            }

            return true;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var inputString = value.ToString();

            if (value == null)
            {
                return new ValidationResult(false, "Значение не может быть пустым");
            }
            if (value == string.Empty)
            {
                return new ValidationResult(false, "Значение не может быть пустым");
            }
            if (!IsUnique(inputString))
            {
                return new ValidationResult(false, $"Название группы не уникальное");
            }
            if (inputString.Length < 3)
            {
                return new ValidationResult(false, $"Строка должна содержать минимум 3 символа");
            }
            if (inputString.Length > 255)
            {
                return new ValidationResult(false, $"Строка должна содержать не более 255 символов");
            }

            return ValidationResult.ValidResult;
        }
    }
}
