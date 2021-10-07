using System;

namespace Brief.Models
{
    public class DateField : BaseField
    {
        public override Type AssociatedType => typeof(DateTime);

        public override string Type => "date";
    }
}
