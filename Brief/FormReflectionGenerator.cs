using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Brief.Attributes;
using Brief.Models;
using Brief.ViewModels;

namespace Brief
{
    public class FormReflectionGenerator
    {
        private List<BaseField> _formFields { get; set; }
        
        public FormReflectionGenerator()
        {
            _formFields = new List<BaseField>();
            GenerateFields(typeof(BriefViewModel));
        }

        private void GenerateFields(Type sourceType)
        {
            var fieldTypes = new Dictionary<Type, Type>();
            foreach (var type in Assembly.GetAssembly(typeof(BaseField)).GetTypes())
            {
                if (type.IsSubclassOf(typeof(BaseField)) && !type.IsAbstract)
                {
                    var instance = Activator.CreateInstance(type);
                    var prop = type.GetProperty("AssociatedType");
                    fieldTypes.Add((Type)prop.GetValue(instance, null),type);
                }
            }

            foreach (var property in sourceType.GetProperties())
            {
                var attribute = property.GetCustomAttribute<FieldAttribute>();

                var fieldType = fieldTypes[property.PropertyType];
                var instance = Activator.CreateInstance(fieldType) as BaseField;
                instance.Name = property.Name;
                if (attribute != null)
                {
                    instance.Question = attribute.GetQuestion();
                }
                _formFields.Add(instance);
            }
        }

        public List<BaseField> GetForm() => _formFields;
    }
}
