using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ODL.DomainModel
{
    public class BusinessLogicException:Exception
    {
        public BusinessLogicException()
        {
        }

        public BusinessLogicException(string message) : base(message)
        {
        }

        public BusinessLogicException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BusinessLogicException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
