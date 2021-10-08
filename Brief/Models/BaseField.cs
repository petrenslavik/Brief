using System;
using System.Text.Json.Serialization;

namespace Brief.Models
{
    public abstract class BaseField
    {
        public abstract string Type { get; }
        public string Question { get; set; }
        public string Name { get; set; }
    }
}
