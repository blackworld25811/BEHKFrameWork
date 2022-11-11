using UnityEngine;
using UnityEngine.EventSystems;

namespace BEHKFrameWork.Message
{
    public class MessageInput : MonoBehaviour, IPointerClickHandler, IDragHandler
    {
        public bool isOnPointerClick;

        public bool isOnDrag;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (isOnPointerClick == false)
            {
                return;
            }
            MessageManager.Instance.SendMessage("OnPointerClick", name, eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (isOnDrag == false)
            {
                return;
            }
            MessageManager.Instance.SendMessage("OnDrag", name, eventData);
        }
    }
}
