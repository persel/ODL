using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ODL.ApplicationServices.DTOModel.Load;
using static System.String;

namespace ODL.ApplicationServices.Validation
{
    public abstract class Validator<T> where T : ValidatableDTO
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
        /// K�r alla valideringsregler och returnera en lista med eventuella fel
        /// </summary>
        public virtual List<ValidationError> Validate(T subject)
        {
            var errors = new List<ValidationError>();

            string idText = Empty;
            var inputDto = subject as InputDTO;

            if (inputDto?.SystemId != null)
                idText = $" (Id: {inputDto.SystemId})";

            foreach (var rule in Rules)
            {
                var result = rule.Evaluate(subject);

                if (result) continue;
                var message = rule.Message + (rule.AddIdToMessage ? idText : Empty);
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

            AddRule(rule, $"F�ltet '{subjectName}.{propertyName}' av typen '{typeName}' f�r ej vara null.", true);
        }

        internal void AboveZero(Expression<Func<T, int>> propertySelector)
        {
            var subjectName = typeof(T).Name;
            var propertyName = ((MemberExpression)propertySelector.Body).Member.Name;
            Func<T, bool> rule = x => propertySelector.Compile().Invoke(x) > 0;

            AddRule(rule, $"F�ltet '{subjectName}.{propertyName}' m�ste vara > 0.", true);
        }

        internal void AboveZero(Expression<Func<T, decimal>> propertySelector)
        {
            var subjectName = typeof(T).Name;
            var propertyName = ((MemberExpression)propertySelector.Body).Member.Name;
            Func<T, bool> rule = x => propertySelector.Compile().Invoke(x) > 0;

            AddRule(rule, $"F�ltet '{subjectName}.{propertyName}' m�ste vara > 0.", true);
        }


        /// <summary>
        /// K�r alla regler och l�gg resultatet i angiven lista.
        /// Returnerar true om subject klarade valideringen.
        /// </summary>
        public bool Validate(T subject, List<ValidationError> validationErrors)
        {
            var errors = Validate(subject);

            if (!errors.Any())
                return true;

            validationErrors.AddRange(errors);
            return false;
        }

        /// <summary>
        /// Skapar och returnerar en ValidationRuleBuilder som kan anv�ndas f�r att peka ut en specifik str�ng-property p� T och
        /// l�gga till regler i Validator f�r den mha ett "fluent api" enligt Builder pattern.
        /// </summary>
        protected ValidationRuleBuilder<T> RuleFor(Expression<Func<T, string>> propertySelector)
        {
            return new ValidationRuleBuilder<T>(propertySelector, this);
        }

        /// <summary>
        /// L�gger till regler f�r metadata
        /// </summary>
        public void RequireMetadata()
        {
            if (!typeof(T).IsSubclassOf(typeof(InputDTO)))
                return;

            RuleFor(subject => (subject as InputDTO).UppdateradDatum).ValidDateTimeFormat();
            RuleFor(subject => (subject as InputDTO).UppdateradAv).WithinMaxLength(10);
            RuleFor(subject => (subject as InputDTO).SkapadDatum).NotNullOrEmpty().ValidDateTimeFormat();
            RuleFor(subject => (subject as InputDTO).SkapadAv).NotNullOrEmpty().WithinMaxLength(10);
        }

        /// <summary>
        /// L�gger till regler f�r systemId
        /// </summary>
        public void RequireSystemId()
        {
            if (!typeof(T).IsSubclassOf(typeof(InputDTO)))
                return;

            RuleFor(subject => (subject as InputDTO).SystemId).NotNullOrEmpty().WithinMaxLength(25);
        }
    }
}