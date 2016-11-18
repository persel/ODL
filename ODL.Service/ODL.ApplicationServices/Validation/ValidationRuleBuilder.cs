using System;
using System.Globalization;
using System.Linq.Expressions;
using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.Validation
{

    public class ValidationRuleBuilder<T> where T : InputDTO
    {
        public const string DateFormat = "yyyy-MM-dd"; // TODO: Flytta denna till konfigurationsfil eller centraliserad plats!

        private Expression<Func<T, string>> PropertySelector { get; }
        private Validator<T> Validator { get; }
        public string SubjectName { get; }
        public string PropertyName { get; }

        public ValidationRuleBuilder(Expression<Func<T, string>> propertySelector, Validator<T> validator)
        {
            PropertySelector = propertySelector;
            Validator = validator;

            SubjectName = typeof(T).Name;
            PropertyName = ((MemberExpression)propertySelector.Body).Member.Name;
            
        }
        
        internal ValidationRuleBuilder<T> NotNull()
        {
            //Func<T, bool> rule = x => PropertySelector.Compile().Invoke(x) != null;
            //Validator.AddRule(rule, $"Fältet '{SubjectName}.{PropertyName}' av typen '{TypeName}' får ej vara null.", true);

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

        internal ValidationRuleBuilder<T> ValidDateFormat()
        {
            Func<T, bool> rule = x => DateFormatCheck(PropertySelector.Compile().Invoke(x)?.ToString());

            Validator.AddRule(rule, $"Fältet '{SubjectName}.{PropertyName}' har ej korrekt datumformat ('{DateFormat}').", true);
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
            return dateString == null || DateTime.TryParseExact(dateString, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue);
        }
    }
}
