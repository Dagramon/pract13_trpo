using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pract12_trpo.Classes.Validations
{
    public class DateValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            var input = Convert.ToDateTime(value);

            if (value == null)
            {
                return new ValidationResult(false, "Значение не может быть пустым");
            }
            if (input >= DateTime.Now)
            {
                return new ValidationResult(false, "Дата не может быть больше сегодняшней");
            }
            if (input < DateTime.Today.AddYears(-125))
            {
                return new ValidationResult(false, "Дата слишком старая");
            }
            return ValidationResult.ValidResult;
        }
    }
}
