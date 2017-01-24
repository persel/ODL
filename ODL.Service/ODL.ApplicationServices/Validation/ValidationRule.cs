using System;
using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.Validation
{
    public class ValidationRule<T> where T : ValidatableDTO
    {

        public string Message { get; private set; }

        public bool AddIdToMessage { get; private set; }

        internal Func<T, bool> RuleDelegate { get; set; }
        //internal T ObjectToValidate { get; set; }

        public ValidationRule(Func<T, bool> rule, string message, bool addIdToMessage = false)
        {
            RuleDelegate = rule;
            Message = message;
            AddIdToMessage = addIdToMessage;
        }

        public bool Evaluate(T subjectToValidate)
        {
            return RuleDelegate(subjectToValidate);
        }
    }
}
