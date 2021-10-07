using System;
using System.Text.Json.Serialization;

namespace Brief.Models
{
    public abstract class BaseField
    {
        [JsonIgnore]
        public abstract Type AssociatedType { get; }
        public abstract string Type { get; }
        public string Question { get; set; }
        public string Name { get; set; }
    }
}
