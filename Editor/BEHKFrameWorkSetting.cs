using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BEHKFrameWork.Editor
{
    public class BEHKFrameWorkSetting : EditorWindow
    {
        public static string Frame = "-1";

        public static string UICodePath = "Assets/";

        private static GUIContent GUIContent_Frame;

        private static GUIContent GUIContent_UICodePath;

        [MenuItem("BEHKFrameWork/Setting")]
        public static void Open()
        {
            // load save
            Frame = LoadData(nameof(Frame), Frame);
            UICodePath = LoadData(nameof(UICodePath), UICodePath);

            UICodePath = EditorUserSettings.GetConfigValue("UICodePath");
            GUIContent_Frame = new GUIContent();
            GUIContent_Frame.text = Frame.ToString();
            GUIContent_UICodePath = new GUIContent();
            GUIContent_UICodePath.text = UICodePath;
            EditorWindow.GetWindow(typeof(BEHKFrameWorkSetting));
        }

        private void OnGUI()
        {
            GUIContent_Frame.text =
                EditorGUILayout.TextField("Frame", GUIContent_Frame.text, GUILayout.MinWidth(100));
            GUIContent_UICodePath.text =
                EditorGUILayout.TextField("UICodePath", GUIContent_UICodePath.text, GUILayout.MinWidth(100));
            Frame = GUIContent_Frame.text;
            UICodePath = GUIContent_UICodePath.text;
        }

        private void OnDestroy()
        {
            // save setting
            SaveData(nameof(Frame), Frame);
            SaveData(nameof(UICodePath), UICodePath);
        }

        public static string GetValue(string name)
        {
            return EditorUserSettings.GetConfigValue(name);
        }

        private static string LoadData(string name, string value)
        {
            string saveFrame = EditorUserSettings.GetConfigValue(name);
            if (saveFrame == null)
            {
                EditorUserSettings.SetConfigValue(name, value);
                return value;
            }
            else
            {
                return saveFrame;
            }
        }

        private static void SaveData(string name, string value)
        {
            if (EditorUserSettings.GetConfigValue(name).Equals(value) == false)
            {
                EditorUserSettings.SetConfigValue(name, value);
            }
        }
    }
}
