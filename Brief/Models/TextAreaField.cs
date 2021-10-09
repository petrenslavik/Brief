using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brief.Models
{
    public class TextAreaField : BaseField
    {
        public override string Type => "text-area";

        public int MaxLength { get; set; } = 500;
    }
}
