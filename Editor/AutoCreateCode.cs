# if UNITY_EDITOR
using System.IO;
using System.Text;
using UnityEditor;

namespace BEHKFrameWork.Editor
{
    public class AutoCreateCode
    {
        [MenuItem("Assets/BEHKFrameWork/AutoCreateCode")]
        public static void CreateCode()
        {
            // get select directory name
            string[] assetGUIDs = Selection.assetGUIDs;
            string path = AssetDatabase.GUIDToAssetPath(assetGUIDs[0]);
            string name = path.Substring(path.LastIndexOf("/") + 1, path.Length - path.LastIndexOf("/") - 1);
            string receiverClassName = "/" + name + "Receiver.cs";
            string dataClassName = "/" + name + "Data.cs";
            // create new class files
            WriteOneCode(path + receiverClassName, ReceiverContent(name));
            WriteOneCode(path + dataClassName, DataContent(name));
            // Add some content to already script
            //WriteOneCode("Assets/Scripts/Main", AddMain(name));
            //WriteOneCode("Assets/Scripts/Contants", AddContants(name));
            AssetDatabase.Refresh();
        }

        private static void WriteOneCode(string fullPath, string content)
        {
            if (File.Exists(fullPath) == false)
            {
                FileStream file = new FileStream(fullPath, FileMode.CreateNew);
                StreamWriter streamWriter = new StreamWriter(file, Encoding.UTF8);
                streamWriter.Write(content);
                streamWriter.Flush();
                streamWriter.Close();
                file.Close();
            }
            else
            {
               /*FileStream file = new FileStream(fullPath, FileMode.Open);
                 StreamWriter streamWriter = new StreamWriter(file, Encoding.UTF8);
                 streamWriter.Write(content);
                 streamWriter.Flush();
                 streamWriter.Close();
                 file.Close();
               */
            }
        }

        private static string ReceiverContent(string name)
        {
            string content;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("using BEHKFrameWork.Message;\n");
            stringBuilder.Append("using System.Collections.Generic;\n");
            stringBuilder.Append("using static Constants;\n");

            stringBuilder.Append("\n");
            stringBuilder.Append("public class " + name + "Receiver : IListener\n");
            stringBuilder.Append("{\n");
            stringBuilder.Append("    private " + name + "Data data;\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("    #region logic register\n");
            stringBuilder.Append("    public string[] ListMessageInterests()\n");
            stringBuilder.Append("    {\n");
            stringBuilder.Append("        List<string> array = new List<string>\n");
            stringBuilder.Append("        {\n");
            stringBuilder.Append("           " + name + ".Init\n");
            stringBuilder.Append("        };\n");
            stringBuilder.Append("        return array.ToArray();\n");
            stringBuilder.Append("    }\n");

            stringBuilder.Append("\n");
            stringBuilder.Append("    public void HandleMessage(Message message)\n");
            stringBuilder.Append("    {\n");
            stringBuilder.Append("        switch (message.Name)\n");
            stringBuilder.Append("        {\n");
            stringBuilder.Append("            case " + name + ".Init:\n");
            stringBuilder.Append("                Init();\n");
            stringBuilder.Append("                break;\n");
            stringBuilder.Append("        }\n");
            stringBuilder.Append("    }\n");
            stringBuilder.Append("    #endregion\n");

            stringBuilder.Append("\n");
            stringBuilder.Append("    #region logic\n");
            stringBuilder.Append("    private void Init()\n");
            stringBuilder.Append("    {\n");
            stringBuilder.Append("        data = MessageManager.Instance.GetListenerData(nameof(" + name + "Receiver)) as " + name + "Data;\n");
            stringBuilder.Append("    }\n");
            stringBuilder.Append("    #endregion\n");
            stringBuilder.Append("}\n");

            content = stringBuilder.ToString();
            return content;
        }

        private static string DataContent(string name)
        {
            string content;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("using BEHKFrameWork.Message;\n");
            stringBuilder.Append("using BEHKFrameWork.Binding;\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("public class " + name + "Data : IData\n");
            stringBuilder.Append("{\n");
            stringBuilder.Append("}\n");

            content = stringBuilder.ToString();
            return content;
        }

        private static string AddMain(string name)
        {
            string content;
            StringBuilder stringBuilder = new StringBuilder();

            content = stringBuilder.ToString();
            return content;
        }

        private static string AddContants(string name)
        {
            string content;
            StringBuilder stringBuilder = new StringBuilder();

            content = stringBuilder.ToString();
            return content;
        }
    }
}
# endif
