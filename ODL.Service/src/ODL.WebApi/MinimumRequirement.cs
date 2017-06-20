using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;

namespace ODL.WebApi
{
    /**
     * Får skapa denna klass här eftersom core teknologi därför platsar den ej i infrastruktur projektet..
     * Här nedan får vi lägga in dom grundläggande kontrollerna 
     * */
    public class MinimumRequirement : IAuthorizationRequirement
    {
        public MinimumRequirement(string anvandarNamn, string applikation, string namn,string key)
        {
            AnvandarNamn = anvandarNamn;
            Applikation = applikation;
            Namn = namn;
            Key = key;
        }

        public string AnvandarNamn { get; }

        public string Applikation { get; }

        public string Namn { get; }
        public string Key { get; set; }
    }
}
