using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ODL.InfrastructureServices
{
    public class Behorighet : IBehorighet
    {
        private IIdentity _identity;

       

        public Behorighet()
        {
          
        }

        public void SetAnvandare(IIdentity identity)
        {
            _identity = identity;
        }

        public bool IsBehorig()
        {
            var tmp = _identity;
            return true;
        }
    }
}
