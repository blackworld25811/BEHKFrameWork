using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    public struct Sample
    {
        public const string Init = nameof(Sample) + nameof(Init);

        public const string Open = nameof(Sample) + nameof(Open);

        public const string Close = nameof(Sample) + nameof(Close);

        public const string Test = nameof(Sample) + nameof(Test);
    }

    public struct Other
    {
        public const string ChangeData = nameof(Other) + nameof(ChangeData);

        public const string ChangeDataSecond = nameof(Other) + nameof(ChangeDataSecond);
    }
}
