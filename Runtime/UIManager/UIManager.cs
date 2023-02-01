using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using BEHKFrameWork.Utility;
using UnityEngine;

namespace BEHKFrameWork.UIManager
{
    public class UIManager : Singleton<UIManager>
    {
        private Dictionary<string, GameObject> dictionary;

        public UIManager()
        {
            dictionary = new Dictionary<string, GameObject>();
        }

        /// <summary>
        /// Initialize the UI class,get GameObject to UI class
        /// </summary>
        /// <param name="UIInstance"></param>
        public void Initialize(object UIInstance)
        {
            dictionary.Clear();
            Canvas[] canvas = Resources.FindObjectsOfTypeAll<Canvas>();
            foreach (var one in canvas)
            {
                if (one.name.Equals(UIInstance.ToString()))
                {
                    GetOneCanvasUIGameObject(one.transform);
                }
            }
            SetUIClassGameObject(UIInstance, UIInstance.GetType());
        }

        private void GetOneCanvasUIGameObject(Transform transform)
        {
            dictionary.Add(transform.name, transform.gameObject);
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);

                GetOneCanvasUIGameObject(child);
            }
        }

        private void SetUIClassGameObject(object instance, Type type)
        {
            FieldInfo[] fieldInfos = type.GetFields();
            foreach (var one in fieldInfos)
            {
                if (one.Name.Equals("GameObject"))
                {
                    UIAttribute attribute = one.GetCustomAttribute<UIAttribute>();
                    GameObject gameObject = dictionary[attribute.Name];
                    one.SetValue(instance, gameObject);
                }
                else
                {
                    Type oneType = type.Assembly.GetType(one.FieldType.FullName);
                    object oneObject = type.Assembly.CreateInstance(one.FieldType.FullName);
                    one.SetValue(instance, oneObject);

                    SetUIClassGameObject(oneObject, oneType);
                }
            }
        }
    }
}
