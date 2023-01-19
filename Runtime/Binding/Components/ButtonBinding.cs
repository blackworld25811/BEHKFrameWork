using System;
using UnityEngine;
using UnityEngine.UI;

namespace BEHKFrameWork.Binding.Component
{
    public class ButtonBinding :ComponentsBinding
    {
        private Button Button;

        private Action Action;

        void Start()
        {
            BindingAttribute bindingAttribute = BindingListenerData.Instance.GetBindingAttribute(GetKey());
            if (bindingAttribute == null) return;

            Button = GetComponent<Button>();
            if (bindingAttribute.PropertyInfo != null)
            {
                Action = bindingAttribute.PropertyInfo.GetValue(bindingAttribute.Object) as Action;
            }
            if (bindingAttribute.FieldInfo != null)
            {
                Action = bindingAttribute.FieldInfo.GetValue(bindingAttribute.Object) as Action;
            }
            BindingComponentValue<object> bindingComponentValue = new BindingComponentValue<object>(Action)
            {
                OnValueChanged = ChangeAddListener
            };
            bindingAttribute.BindingComponentValueList.Add(bindingComponentValue);
        }

        // add listener again,because action is null in the start
        private void ChangeAddListener(object action)
        {
            Action = action as Action;
            Button.onClick.RemoveAllListeners();
            Button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Action();
        }
    }
}