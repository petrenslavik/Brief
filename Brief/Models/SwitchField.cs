using System;

namespace Brief.Models
{
    public class SwitchField : BaseField
    {
        public override Type AssociatedType => typeof(bool);

        public override string Type => "switch";
    }
}
