using System;

namespace Brief.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldAttribute : Attribute
    {
        private string question;
        public FieldAttribute(string question)
        {
            this.question = question;
        }

        public string GetQuestion() => question;
    }
}
