using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODL.ApplicationServices.DTOModel.Load
{
    public abstract class InputDTO
    {
        public string SystemId { get; set; }

        public string UppdateradDatum { get; set; }

        public string UppdateradAv { get; set; }

        public string SkapadDatum { get; set; }

        public string SkapadAv { get; set; }

    }
}
