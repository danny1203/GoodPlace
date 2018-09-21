using System;
using System.Text.RegularExpressions;

namespace GoodPlaces.Core.Helpers
{
    public class Validations
    {
        public Validations()
        {
        }

        public bool ValidEmail(string Email, string pwd)
        {
            var emailPattern = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";
            if (Regex.IsMatch(Email, emailPattern))
            {
                //IsVisible = false;
                return true;
            }
            else
            {
                //IsVisible = true;
                return false;
            }
        }

    }
}
