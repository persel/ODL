using System;

namespace ODL.DomainModel.Common
{
    [AttributeUsage(AttributeTargets.Field)]
    public class VisningstextAttribute : Attribute
    {
        public string Text { get; set; }
        public VisningstextAttribute(string text)
        {
            Text = text;
        }
    }
}
