using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BEHKFrameWork.Utility;

namespace BEHKFrameWork.Message
{
    public class MessageGameObject : Singleton<MessageGameObject>
    {
        public void Execute(Message message)
        {
            List<ListenerGameObject> listernerGameObjects = MessageManager.Instance.GetListenerGameObject(message.Name);

            foreach (ListenerGameObject listernerGameObject in listernerGameObjects)
            {
                ChangeGameObject(listernerGameObject, message);
            }
        }

        private void ChangeGameObject(ListenerGameObject listernerGameObject, Message message)
        {
            string type = MessageManager.Instance.GetListenerGameObjectType(message.Name);
            Transform transform = listernerGameObject.transform;
            switch (type)
            {
                case nameof(listernerGameObject.Active):
                    listernerGameObject.transform.gameObject.SetActive((bool)message.Body);
                    break;
                case nameof(listernerGameObject.NotActive):
                    listernerGameObject.transform.gameObject.SetActive(!(bool)message.Body);
                    break;
                case nameof(listernerGameObject.PositionX):
                    listernerGameObject.transform.localPosition = new Vector3((float)message.Body, transform.localPosition.y, transform.localPosition.z);
                    break;
                case nameof(listernerGameObject.PositionY):
                    listernerGameObject.transform.localPosition = new Vector3(transform.localPosition.x, (float)message.Body, transform.localPosition.z);
                    break;
                case nameof(listernerGameObject.PositionZ):
                    listernerGameObject.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, (float)message.Body);
                    break;
                case nameof(listernerGameObject.RotationX):
                    listernerGameObject.transform.localEulerAngles = new Vector3((float)message.Body, transform.localEulerAngles.y, transform.localEulerAngles.z);
                    break;
                case nameof(listernerGameObject.RotationY):
                    listernerGameObject.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, (float)message.Body, transform.localEulerAngles.z);
                    break;
                case nameof(listernerGameObject.RotationZ):
                    listernerGameObject.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, (float)message.Body);
                    break;
                case nameof(listernerGameObject.ScaleX):
                    listernerGameObject.transform.localScale = new Vector3((float)message.Body, transform.localScale.y, transform.localScale.z);
                    break;
                case nameof(listernerGameObject.ScaleY):
                    listernerGameObject.transform.localScale = new Vector3(transform.localScale.x, (float)message.Body, transform.localScale.z);
                    break;
                case nameof(listernerGameObject.ScaleZ):
                    listernerGameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, (float)message.Body);
                    break;
                case nameof(listernerGameObject.Text):
                    listernerGameObject.GetComponent<Text>().text = (string)message.Body;
                    break;
                case nameof(listernerGameObject.Color):
                    Text text = listernerGameObject.GetComponent<Text>();
                    Image image = listernerGameObject.GetComponent<Image>();
                    if (text != null)
                    {
                        text.color = (Color)message.Body;
                    }
                    if (image != null)
                    {
                        image.color = (Color)message.Body;
                    }
                    break;
                case nameof(listernerGameObject.ToggleOn):
                    listernerGameObject.GetComponent<Toggle>().isOn = (bool)message.Body;
                    break;
                case nameof(listernerGameObject.ButtonOnClick):
                    listernerGameObject.GetComponent<Button>().onClick.Invoke();
                    break;
            }
        }
    }
}
