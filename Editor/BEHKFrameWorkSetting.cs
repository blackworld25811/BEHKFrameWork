using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BEHKFrameWork.Editor
{
    public class BEHKFrameWorkSetting : EditorWindow
    {
        public static int Frame = -1;

        public static string UICodePath = "Assets/";

        private static GUIContent GUIContent_Frame;

        private static GUIContent GUIContent_UICodePath;

        [MenuItem("BEHKFrameWork/Setting")]
        public static void OpenWindwo()
        {
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
            Frame = int.Parse(GUIContent_Frame.text);
            UICodePath = GUIContent_UICodePath.text;
        }
    }
}
