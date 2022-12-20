namespace BEHKFrameWork.Binding
{
    internal class DataReflectionInformation
    {
        private string name;

        private BindingAttribute bindingAttribute;

        /// <summary>
        /// property or field name
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value;
        }

        /// <summary>
        /// property or field attribute
        /// </summary>
        public BindingAttribute BindingAttribute
        {
            get => bindingAttribute;
            set => bindingAttribute = value;
        }


        public DataReflectionInformation(string name, BindingAttribute bindingAttribute)
        {
            Name = name;
            BindingAttribute = bindingAttribute;
        }
    }
}