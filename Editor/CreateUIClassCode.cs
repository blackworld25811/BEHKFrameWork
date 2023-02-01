# if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace BEHKFrameWork.Editor
{
    public class CreateUIClassCode
    {
        [MenuItem("GameObject/BEHKFrameWork/CreateUIClassCode")]
        public static void CreateCode()
        {
            // iterate over all of the Canvas,one Canvas is a UI tree
            Canvas[] canvas = Resources.FindObjectsOfTypeAll<Canvas>();

            foreach (var one in canvas)
            {
                string content = Content(one.transform);
                Utility.Utility.WriteFile("Assets/" + one.name + ".cs", content);
            }
        }

        private static string Content(Transform self)
        {
            string content;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("using UnityEngine;\n");
            stringBuilder.Append("using BEHKFrameWork.Utility;\n");
            stringBuilder.Append("using BEHKFrameWork.UIManager;\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("public class " + FixName(self.name) + " : Singleton<Canvas>\n");
            stringBuilder.Append("{\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("   [UI(" + "\"" + self.gameObject.GetInstanceID() + "\"" + ")]\n");
            stringBuilder.Append("   public GameObject GameObject;\n");
            stringBuilder.Append("\n");
            for (int i = 0; i < self.childCount; i++)
            {
                string childName = FixName(self.GetChild(i).name);
                stringBuilder.Append("   public Sub_" + childName + " " + childName + ";\n");
                stringBuilder.Append("\n");

                SubClassContent(self.GetChild(i), stringBuilder);
                // keep blank line is right
                if (i != self.childCount - 1)
                {
                    stringBuilder.Append("\n");
                }
            }
            stringBuilder.Append("}\n");
            content = stringBuilder.ToString();
            return content;
        }

        private static void SubClassContent(Transform self, StringBuilder stringBuilder)
        {
            stringBuilder.Append("   public class Sub_" + FixName(self.name) + "\n");
            stringBuilder.Append("   {\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("      [UI(" + "\"" + self.gameObject.GetInstanceID() + "\"" + ")]\n");
            stringBuilder.Append("      public GameObject GameObject;\n");
            if (self.childCount > 0)
            {
                stringBuilder.Append("\n");
            }
            for (int i = 0; i < self.childCount; i++)
            {
                string childName = FixName(self.GetChild(i).name);
                stringBuilder.Append("      public Sub_" + childName + " " + childName + ";\n");
                stringBuilder.Append("\n");

                SubClassContent(self.GetChild(i), stringBuilder);
                // keep blank line is right
                if (i != self.childCount - 1)
                {
                    stringBuilder.Append("\n");
                }
            }
            stringBuilder.Append("   }\n");
        }

        private static string FixName(string name)
        {
            name = Utility.Utility.RemoveStringBlank(name);
            name = name.Replace("(", "_");
            name = name.Replace(")", "");
            return name;
        }
    }
}
# endif
