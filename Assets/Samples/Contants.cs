using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contants
{
    public struct Sample
    {
        public const string Init = nameof(Sample) + "Init";

        public const string Open = nameof(Sample) + "Open";

        public const string Close = nameof(Sample) + "Close";
    }

    public struct Other
    {
        public const string ChangeData = nameof(Other) + "ChangeData";

    }
}
