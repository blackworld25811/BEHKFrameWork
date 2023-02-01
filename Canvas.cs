using UnityEngine;
using BEHKFrameWork.Utility;
using BEHKFrameWork.UIManager;

public class Canvas : Singleton<Canvas>
{

    [UI("Canvas")]
    public GameObject GameObject;

    public Sub_Panel_sample Panel_sample;

    public class Sub_Panel_sample
    {

        [UI("Panel_sample")]
        public GameObject GameObject;

        public Sub_Text_0 Text_0;

        public class Sub_Text_0
        {

            [UI("Text_0")]
            public GameObject GameObject;
        }

        public Sub_Text_1 Text_1;

        public class Sub_Text_1
        {

            [UI("Text_1")]
            public GameObject GameObject;
        }

        public Sub_Button_Legacy Button_Legacy;

        public class Sub_Button_Legacy
        {

            [UI("Button (Legacy)")]
            public GameObject GameObject;

            public Sub_Text_Legacy Text_Legacy;

            public class Sub_Text_Legacy
            {

                [UI("Text (Legacy)")]
                public GameObject GameObject;
            }
        }

        public Sub_Image Image;

        public class Sub_Image
        {

            [UI("Image")]
            public GameObject GameObject;
        }

        public Sub_Toggle Toggle;

        public class Sub_Toggle
        {

            [UI("Toggle")]
            public GameObject GameObject;

            public Sub_Background Background;

            public class Sub_Background
            {

                [UI("Background")]
                public GameObject GameObject;

                public Sub_Checkmark Checkmark;

                public class Sub_Checkmark
                {

                    [UI("Checkmark")]
                    public GameObject GameObject;
                }
            }

            public Sub_Label Label;

            public class Sub_Label
            {

                [UI("Label")]
                public GameObject GameObject;
            }
        }
    }

    public Sub_Panel_sample_TMP Panel_sample_TMP;

    public class Sub_Panel_sample_TMP
    {

        [UI("Panel_sample_TMP")]
        public GameObject GameObject;

        public Sub_Text_TMP Text_TMP;

        public class Sub_Text_TMP
        {

            [UI("Text (TMP)")]
            public GameObject GameObject;
        }

        public Sub_InputField_TMP InputField_TMP;

        public class Sub_InputField_TMP
        {

            [UI("InputField (TMP)")]
            public GameObject GameObject;

            public Sub_TextArea TextArea;

            public class Sub_TextArea
            {

                [UI("Text Area")]
                public GameObject GameObject;

                public Sub_Placeholder Placeholder;

                public class Sub_Placeholder
                {

                    [UI("Placeholder")]
                    public GameObject GameObject;
                }

                public Sub_Text Text;

                public class Sub_Text
                {

                    [UI("Text")]
                    public GameObject GameObject;
                }
            }
        }
    }
}
