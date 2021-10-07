using System;

namespace Brief.Models
{
    public class TextField: BaseField
    {
        public override Type AssociatedType => typeof(string);

        public override string Type => "text";
    }
}
