using UnityEngine;

namespace BEHKFrameWork.Message
{
    public class ListenerGameObject : MonoBehaviour, IListenerGameObject
    {
        public string Active;

        public string NotActive;

        public string PositionX;

        public string PositionY;

        public string PositionZ;

        public string RotationX;

        public string RotationY;

        public string RotationZ;

        public string ScaleX;

        public string ScaleY;

        public string ScaleZ;

        public string Text;

        public string Color;

        public string ToggleOn;

        public string ButtonOnClick;


        void Awake()
        {
            RegisterAndBinging(Active, nameof(Active));
            RegisterAndBinging(NotActive, nameof(NotActive));
            RegisterAndBinging(PositionX, nameof(PositionX));
            RegisterAndBinging(PositionY, nameof(PositionY));
            RegisterAndBinging(PositionZ, nameof(PositionZ));
            RegisterAndBinging(RotationX, nameof(RotationX));
            RegisterAndBinging(RotationY, nameof(RotationY));
            RegisterAndBinging(RotationZ, nameof(RotationZ));
            RegisterAndBinging(ScaleX, nameof(ScaleX));
            RegisterAndBinging(ScaleY, nameof(ScaleY));
            RegisterAndBinging(ScaleZ, nameof(ScaleZ));
            RegisterAndBinging(Text, nameof(Text));
            RegisterAndBinging(Color, nameof(Color));
            RegisterAndBinging(ToggleOn, nameof(ToggleOn));
            RegisterAndBinging(ButtonOnClick, nameof(ButtonOnClick));
        }

        public void Execute(Message message)
        {
            MessageGameObject.Instance.Execute(message);
        }

        public void RegisterAndBinging(string property, string type)
        {
            if (property == null)
            {
                return;
            }
            if (property.Trim().Length > 0)
            {
                MessageManager.Instance.RegisterListenerGameObject(property, this);
                MessageManager.Instance.BindingDate(property, type, this);
            }
        }
    }
}
