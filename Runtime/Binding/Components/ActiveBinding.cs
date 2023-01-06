using UnityEngine;

namespace BEHKFrameWork.Binding.Component
{
    public class ActiveBinding : MonoBehaviour
    {
        public string Key;

        private void Start()
        {
            BindingAttribute bindingAttribute = BindingListenerData.Instance.GetBindingAttribute(Key);
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
