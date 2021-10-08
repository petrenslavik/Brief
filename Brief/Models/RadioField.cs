﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brief.Models
{
    public class RadioField : BaseField
    {
        public override string Type => "radio";

        public IEnumerable<string> Options { get; set; }
    }
}
