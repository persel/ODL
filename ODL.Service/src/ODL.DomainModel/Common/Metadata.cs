﻿using System;

namespace ODL.DomainModel.Common
{
    public class Metadata
    {
        public Metadata(){}
        public Metadata(DateTime? uppdateradDatum, string uppdateradAv, DateTime? skapadDatum, string skapadAv)
        {
            UppdateradDatum = uppdateradDatum;
            UppdateradAv = uppdateradAv;
            SkapadDatum = skapadDatum;
            SkapadAv = skapadAv;
        }

        public Metadata(DateTime skapadDatum, string skapadAv)
        {
            SkapadDatum = skapadDatum;
            SkapadAv = skapadAv;
        }

        public DateTime? UppdateradDatum { get; private set; }
        public string UppdateradAv { get; private set; }
        public DateTime? SkapadDatum { get; private set; }
        public string SkapadAv { get; private set; }
    }
}
