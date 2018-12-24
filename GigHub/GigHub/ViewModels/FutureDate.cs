using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GigHub.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var isValid = DateTime.TryParseExact(Convert.ToString(value), "d MMM YYYY", CultureInfo.CurrentCulture, DateTimeStyles.None, out var dateTime);
            return (isValid && dateTime > DateTime.Now);
        }
    }
}