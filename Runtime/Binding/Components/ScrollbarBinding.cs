using System;
using UnityEngine;
using UnityEngine.UI;

namespace BEHKFrameWork.Binding.Component
{
    public class ScrollbarBinding : ComponentsBinding
    {
        private Scrollbar Scrollbar;

        private Action<float> Action;

        void Start()
        {
            BindingAttribute bindingAttribute = BindingListenerData.Instance.GetBindingAttribute(GetKey());
            if (bindingAttribute == null) return;

            Scrollbar = GetComponent<Scrollbar>();
            if (bindingAttribute.PropertyInfo != null)
            {
                Action = bindingAttribute.PropertyInfo.GetValue(bindingAttribute.Object) as Action<float>;
            }
            if (bindingAttribute.FieldInfo != null)
            {
                Action = bindingAttribute.FieldInfo.GetValue(bindingAttribute.Object) as Action<float>;
            }
            BindingComponentValue<object> bindingComponentValue = new BindingComponentValue<object>(Action)
            {
                OnValueChanged = ChangeAddListener
            };
            bindingAttribute.BindingComponentValueList.Add(bindingComponentValue);
        }

        private void ChangeAddListener(object action)
        {
            Action = action as Action<float>;
            Scrollbar.onValueChanged.RemoveAllListeners();
            Scrollbar.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(float value)
        {
            Action?.Invoke(value);
        }
    }
}
