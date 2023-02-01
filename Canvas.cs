using UnityEngine;
using BEHKFrameWork.Utility;
using BEHKFrameWork.UIManager;

public class Canvas : Singleton<Canvas>
{

    [UI("19946")]
    public GameObject GameObject;

    public Sub_Panel_sample Panel_sample;

    public class Sub_Panel_sample
    {

        [UI("19932")]
        public GameObject GameObject;

        public Sub_Text_0 Text_0;

        public class Sub_Text_0
        {

            [UI("19910")]
            public GameObject GameObject;
        }

        public Sub_Text_1 Text_1;

        public class Sub_Text_1
        {

            [UI("20012")]
            public GameObject GameObject;
        }

        public Sub_Button_Legacy Button_Legacy;

        public class Sub_Button_Legacy
        {

            [UI("19984")]
            public GameObject GameObject;

            public Sub_Text_Legacy Text_Legacy;

            public class Sub_Text_Legacy
            {

                [UI("19890")]
                public GameObject GameObject;
            }
        }

        public Sub_Button_Legacy1 Button_Legacy1;

        public class Sub_Button_Legacy1
        {

            [UI("-1628")]
            public GameObject GameObject;

            public Sub_Text_Legacy Text_Legacy;

            public class Sub_Text_Legacy
            {

                [UI("-1626")]
                public GameObject GameObject;
            }
        }

        public Sub_Image Image;

        public class Sub_Image
        {

            [UI("19974")]
            public GameObject GameObject;
        }

        public Sub_Toggle Toggle;

        public class Sub_Toggle
        {

            [UI("19996")]
            public GameObject GameObject;

            public Sub_Background Background;

            public class Sub_Background
            {

                [UI("20036")]
                public GameObject GameObject;

                public Sub_Checkmark Checkmark;

                public class Sub_Checkmark
                {

                    [UI("20028")]
                    public GameObject GameObject;
                }
            }

            public Sub_Label Label;

            public class Sub_Label
            {

                [UI("20004")]
                public GameObject GameObject;
            }
        }
    }

    public Sub_Panel_sample_TMP Panel_sample_TMP;

    public class Sub_Panel_sample_TMP
    {

        [UI("19882")]
        public GameObject GameObject;

        public Sub_Text_TMP Text_TMP;

        public class Sub_Text_TMP
        {

            [UI("19866")]
            public GameObject GameObject;
        }

        public Sub_InputField_TMP InputField_TMP;

        public class Sub_InputField_TMP
        {

            [UI("19898")]
            public GameObject GameObject;

            public Sub_TextArea TextArea;

            public class Sub_TextArea
            {

                [UI("20022")]
                public GameObject GameObject;

                public Sub_Placeholder Placeholder;

                public class Sub_Placeholder
                {

                    [UI("19922")]
                    public GameObject GameObject;
                }

                public Sub_Text Text;

                public class Sub_Text
                {

                    [UI("19956")]
                    public GameObject GameObject;
                }
            }
        }
    }
}
