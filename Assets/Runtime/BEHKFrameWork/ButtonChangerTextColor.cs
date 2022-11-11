using UnityEngine;
using UnityEngine.UI;

namespace BEHKFrameWork
{
    public class ButtonChangerTextColor : MonoBehaviour
    {
        public Color sourceColor;

        public Color targetColor;

        private Text text;

        void Awake()
        {
            text = transform.Find("Text").GetComponent<Text>();
        }

        public void changeTarget()
        {
            text.color = targetColor;
        }

        public void changeSource()
        {
            text.color = sourceColor;
        }
    }
}
