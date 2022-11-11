using System;

namespace BEHKFrameWork.Binding
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class BindingAttribute : Attribute
    {
        private string key;

        public string Key { get => key; set => key = value; }

        public BindingAttribute(string key)
        {
            Key = key;
        }
    }
}
