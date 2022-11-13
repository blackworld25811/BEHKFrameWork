using System;
using System.Reflection;

namespace BEHKFrameWork.Binding
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class BindingAttribute : Attribute
    {
        private string key;

        private object @object;

        private PropertyInfo propertyInfo;

        private FieldInfo fieldInfo;

        private object oldPropertyValue;

        private object oldFieldValue;

        /// <summary>
        /// 
        /// </summary>
        public string Key { get => key; set => key = value; }

        /// <summary>
        /// 
        /// </summary>
        public object Object { get => @object; set => @object = value; }

        /// <summary>
        /// 
        /// </summary>
        public PropertyInfo PropertyInfo { get => propertyInfo; set => propertyInfo = value; }

        /// <summary>
        /// 
        /// </summary>
        public FieldInfo FieldInfo { get => fieldInfo; set => fieldInfo = value; }

        /// <summary>
        /// 
        /// </summary>
        public object OldPropertyValue { get => oldPropertyValue; set => oldPropertyValue = value; }

        /// <summary>
        ///  
        /// </summary>
        public object OldFieldValue { get => oldFieldValue; set => oldFieldValue = value; }


        public BindingAttribute(string key)
        {
            Key = key;
        }
    }
}
