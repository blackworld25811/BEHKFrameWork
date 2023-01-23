using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BEHKFrameWork.Binding.Component
{
    public class InputFieldProBinding : ComponentsBinding
    {
        private TextMeshProUGUI Text;

        private void Start()
        {
            BindingAttribute bindingAttribute = BindingListenerData.Instance.GetBindingAttribute(GetKey());
            if (bindingAttribute == null) return;

            Text = GetComponent<TextMeshProUGUI>();
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
