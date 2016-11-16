using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODL.ApplicationServices.Validation
{
    public class ValidationError
    {
        public string Message { get; private set; }

        public ValidationError(string message)
        {
            Message = message;
        }
    }
}
