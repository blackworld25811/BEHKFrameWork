using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BEHKFrameWork.Utility;
using UnityEngine;

namespace BEHKFrameWork.UIManager
{
    public class UIManager : Singleton<UIManager>
    {
        /// <summary>
        /// Initialize the UI class,get GameObject to UI class
        /// </summary>
        /// <param name="UIInstance"></param>
        public void Initialize(object UIInstance)
        {
            Canvas[] canvas = Resources.FindObjectsOfTypeAll<Canvas>();
            foreach (var one in canvas)
            {
                if (one.gameObject.activeSelf == false)
                {
                    continue;
                }
                if (one.name.Equals(UIInstance.ToString()))
                {
                    GetOneCanvasUIGameObject(UIInstance, UIInstance.GetType(), one.transform);
                }
            }
        }

        private void GetOneCanvasUIGameObject(object instance, Type type, Transform transform)
        {
            FieldInfo[] fieldInfos = type.GetFields();
            int index = -1;
            foreach (var one in fieldInfos)
            {
                if (one.Name.Equals("GameObject"))
                {
                    GameObject gameObject = transform.gameObject;
                    one.SetValue(instance, gameObject);
                }
                else
                {
                    index++;
                    Type oneType = type.Assembly.GetType(one.FieldType.FullName);
                    object oneObject = type.Assembly.CreateInstance(one.FieldType.FullName);
                    one.SetValue(instance, oneObject);

                    GetOneCanvasUIGameObject(oneObject, oneType, transform.GetChild(index));
                }
            }
        }
    }
}
