using BEHKFrameWork.Message;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MessageManager.Instance.RegisterListener(nameof(SampleReceiver), new SampleReceiver(), new SampleData());
        MessageManager.Instance.RegisterListener(nameof(OtherReceiver), new OtherReceiver(), new OtherData());
        MessageManager.Instance.SendMessage(Contants.Sample.Init);

        new TestData();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
