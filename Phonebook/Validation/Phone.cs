using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Phonebook.Validation
{
    class Phone : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(Regex.IsMatch((string)value, @"\+639[0-9]{9}|09[0-9]{9}")||(string)value=="")
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, null);
        }
    }
}
