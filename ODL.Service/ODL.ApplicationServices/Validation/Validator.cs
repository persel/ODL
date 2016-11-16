using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.Validation
{
    public abstract class Validator<T> where T : InputDTO
    {
        public List<ValidationRule<T>> Rules { get; internal set; }

        protected Validator()
        {
            Rules = new List<ValidationRule<T>>();
        }

        internal void AddRule(Func<T, bool> rule, string message, bool addIdToMessage = false)
        {
            Rules.Add(new ValidationRule<T>(rule, message, addIdToMessage));
        }


        /// <summary>
        /// Kör alla regler
        /// </summary>
        public List<ValidationError> Validate(T subject)
        {
            var errors = new List<ValidationError>();
            var idText = $" (Id: {subject.SystemId})";

            foreach (var rule in Rules)
            {
                var result = rule.Evaluate(subject);

                if (result) continue;
                var message = rule.Message + (rule.AddIdToMessage ? idText : string.Empty);
                errors.Add(new ValidationError(message));
            }

            return errors;
        }

        internal void NotNull<T2>(Expression<Func<T, T2>> propertySelector)
        {
            var subjectName = typeof(T).Name;
            var propertyName = ((MemberExpression)propertySelector.Body).Member.Name;
            var typeName = typeof(T2).Name;
            Func<T, bool> rule = x => propertySelector.Compile().Invoke(x) != null;

            AddRule(rule, $"Fältet '{subjectName}.{propertyName}' av typen '{typeName}' får ej vara null.", true);
        }

        /// <summary>
        /// Kör alla regler och lägg resultatet i angiven lista.
        /// Returnerar false om valideringsfel påträffades.
        /// </summary>
        public bool Validate(T subject, List<ValidationError> validationErrors)
        {
            var errors = Validate(subject);

            if (!errors.Any())
                return true;

            validationErrors.AddRange(errors);
            return false;
        }

        protected ValidationRuleBuilder<T> RuleFor(Expression<Func<T, string>> propertySelector)
        {
            return new ValidationRuleBuilder<T>(propertySelector, this);
        }

        /// <summary>
        /// Lägger till regler för systemId och metadata
        /// </summary>
        public void AddStandardRules()
        {
            RuleFor(subject => subject.SystemId).NotNullOrEmpty().WithinMaxLength(25);

            RuleFor(subject => subject.UppdateradDatum).ValidDateFormat();
            RuleFor(subject => subject.UppdateradAv).WithinMaxLength(10);
            RuleFor(subject => subject.SkapadDatum).NotNullOrEmpty().ValidDateFormat();
            RuleFor(subject => subject.SkapadAv).NotNullOrEmpty().WithinMaxLength(10);
        }
    }
}