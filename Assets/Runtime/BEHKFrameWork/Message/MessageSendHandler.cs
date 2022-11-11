using UnityEngine;
using UnityEngine.UI;

namespace BEHKFrameWork.Message
{
    public class MessageSendHandler : MonoBehaviour
    {
        public string Name;

        public string Type;

        public string Body;

        public void Awake()
        {
            if (Name == null)
            {
                return;
            }
            Toggle toggle = transform.GetComponent<Toggle>();
            if (toggle != null)
            {
                toggle.onValueChanged.AddListener((bool value) => { ToggleOnValueChanged(value); });
            }
            Button button = transform.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(ButtonOnClick);
            }
        }

        private void ToggleOnValueChanged(bool value)
        {
            MessageManager.Instance.SendMessage(Name, Type, value);
        }

        private void ButtonOnClick()
        {
            MessageManager.Instance.SendMessage(Name, Type, true);
        }
    }
}
