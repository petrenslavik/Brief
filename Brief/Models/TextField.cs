using System;

namespace Brief.Models
{
    public class TextField: BaseField
    {
        public override string Type => "text";

        public int MinLength { get; set; }
        public int MaxLength { get; set; }
    }
}
