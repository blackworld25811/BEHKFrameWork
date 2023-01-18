using UnityEngine;
using UnityEngine.UI;

namespace BEHKFrameWork.Binding.Component
{
    public class TextBinding : ComponentsBinding
    {
       
        private Text Text;

        private void Start()
        {
            BindingAttribute bindingAttribute = BindingListenerData.Instance.GetBindingAttribute(GetKey());
            if (bindingAttribute == null) return;

            Text = GetComponent<Text>();
            BindingComponentValue<object> bindingComponentValue = new BindingComponentValue<object>(Text.text)
            {
                OnValueChanged = ChangeText
            };
            bindingAttribute.BindingComponentValueList.Add(bindingComponentValue);
        }

        private void ChangeText(object text)
        {
            Text.text = text as string;
        }
    }
}