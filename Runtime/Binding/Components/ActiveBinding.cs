using UnityEngine;

namespace BEHKFrameWork.Binding.Component
{
    public class ActiveBinding : ComponentsBinding
    {
        private void Start()
        {
            BindingAttribute bindingAttribute = BindingListenerData.Instance.GetBindingAttribute(GetKey());
            if (bindingAttribute == null) return;

            BindingComponentValue<object> bindingComponentValue = new BindingComponentValue<object>(gameObject)
            {
                OnValueChanged = ChangeActive
            };
            bindingAttribute.BindingComponentValueList.Add(bindingComponentValue);
        }

        private void ChangeActive(object isActive)
        {
            gameObject.SetActive((bool)isActive);
        }
    }
}
