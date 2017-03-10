using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text.RegularExpressions;
using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.Validation
{
    /// <summary>
    /// Används för att lägga till regler i Validator (anges i konstruktorn) för en specifik string-property på T mha ett "fluent api" enligt Builder pattern.
    /// </summary>

    public class ValidationRuleBuilder<T> where T : ValidatableDTO
    {
        public const string DateFormat = "yyyy-MM-dd"; // TODO: Flytta denna till konfigurationsfil eller centraliserad plats!
        public const string DateTimeFormat = "yyyy-MM-dd HH:mm";

        private Expression<Func<T, string>> PropertySelector { get; }
        private Validator<T> Validator { get; }
        public string SubjectName { get; }
        public string PropertyName { get; }

        internal ValidationRuleBuilder(Expression<Func<T, string>> propertySelector, Validator<T> validator)
        {
            PropertySelector = propertySelector;
            Validator = validator;

            SubjectName = typeof(T).Name;
            PropertyName = ((MemberExpression)propertySelector.Body).Member.Name;
        }
        
        internal ValidationRuleBuilder<T> NotNull()
        {
            Validator.NotNull(PropertySelector);
            return this;
        }

        internal ValidationRuleBuilder<T> NotNullOrEmpty()
        {
            Func<T, bool> rule = x => !string.IsNullOrEmpty(PropertySelector.Compile().Invoke(x));

            Validator.AddRule(rule, $"Fältet '{SubjectName}.{PropertyName}' saknar värde.", true);
            return this;
        }

        internal ValidationRuleBuilder<T> WithinMaxLength(int maxLength)
        {
            Func<T, bool> rule = x => MaxCheck(PropertySelector.Compile().Invoke(x), maxLength);
            
            Validator.AddRule(rule, $"Fältet '{SubjectName}.{PropertyName}' får innehålla max {maxLength} tecken.", true);
            return this;
        }

        internal ValidationRuleBuilder<T> isValidMailAdress()
        {
            //Func<T, bool> rule = x => MaxCheck(PropertySelector.Compile().Invoke(x), maxLength);
            Func<T, bool> rule = m => IsValidEmailAdress(PropertySelector.Compile().Invoke(m));

            Validator.AddRule(rule, $"Epostadressen '{SubjectName}.{PropertyName}' har fel format.", true);
            return this;
        }

        internal ValidationRuleBuilder<T> ValidDateFormat()
        {
            Func<T, bool> rule = x => DateFormatCheck(PropertySelector.Compile().Invoke(x)?.ToString());

            Validator.AddRule(rule, $"Fältet '{SubjectName}.{PropertyName}' har ej korrekt datumformat ('{DateFormat}').", true);
            return this;
        }

        internal ValidationRuleBuilder<T> ValidDateTimeFormat()
        {
            Func<T, bool> rule = x => DateTimeFormatCheck(PropertySelector.Compile().Invoke(x)?.ToString());

            Validator.AddRule(rule, $"Fältet '{SubjectName}.{PropertyName}' har ej korrekt datumformat ('{DateTimeFormat}').", true);
            return this;
        }

        private bool MaxCheck(string theString, int maxLength)
        {
            bool result =  theString == null || theString.Length <= maxLength;

            return result;
        }

        private bool DateFormatCheck(string dateString)
        {
            DateTime dateValue;
            return string.IsNullOrEmpty(dateString) || DateTime.TryParseExact(dateString, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue);
        }

        private bool DateTimeFormatCheck(string dateTimeString)
        {
            DateTime dateValue;
            return string.IsNullOrEmpty(dateTimeString) || DateTime.TryParseExact(dateTimeString, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue);
        }


        private bool IsValidEmailAdress(string emailaddress)
        {
            //Fångar felaktiga epostadresser enligt RFC2822s
            return Regex.IsMatch(emailaddress, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            //try
            //{
            //    MailAddress m = new MailAddress(emailaddress);

            //    return true;
            //}
            //catch (FormatException)
            //{
            //    return false;
            //}
        }
    }
}
