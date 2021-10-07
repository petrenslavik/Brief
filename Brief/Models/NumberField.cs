using System;

namespace Brief.Models
{
    public class NumberField : BaseField
    {
        public override Type AssociatedType => typeof(long);

        public override string Type => "number";
    }
}
