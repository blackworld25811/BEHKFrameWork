# if UNITY_EDITOR
using System.IO;
using System.Text;
using UnityEditor;
using BEHKFrameWork.Utility;

namespace BEHKFrameWork.Editor
{
    public class CreateReceiverCode
    {
        [MenuItem("Assets/BEHKFrameWork/CreateReceiverCode")]
        public static void CreateCode()
        {
            // get select directory name
            string[] assetGUIDs = Selection.assetGUIDs;
            string path = AssetDatabase.GUIDToAssetPath(assetGUIDs[0]);
            string name = path.Substring(path.LastIndexOf("/") + 1, path.Length - path.LastIndexOf("/") - 1);
            string receiverClassName = "/" + name + "Receiver.cs";
            string dataClassName = "/" + name + "Data.cs";
            // create new class files
            Utility.Utility.WriteFile(path + receiverClassName, ReceiverContent(name));
            Utility.Utility.WriteFile(path + dataClassName, DataContent(name));
            // Add some content to already script
            //Utility.Utility.WriteFile("Assets/Scripts/Main", AddMain(name));
            //Utility.Utility.WriteFile("Assets/Scripts/Contants", AddContants(name));
            AssetDatabase.Refresh();
        }

        private static string ReceiverContent(string name)
        {
            string content;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("using UnityEngine;\n");
            stringBuilder.Append("using BEHKFrameWork.Message;\n");
            stringBuilder.Append("using System.Collections.Generic;\n");
            stringBuilder.Append("using static Constants;\n");

            stringBuilder.Append("\n");
            stringBuilder.Append("public class " + name + "Receiver : IListener\n");
            stringBuilder.Append("{\n");
            stringBuilder.Append("    private " + name + "Data data;\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("    #region register\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("    public string[] ListMessageInterests()\n");
            stringBuilder.Append("    {\n");
            stringBuilder.Append("        List<string> array = new List<string>\n");
            stringBuilder.Append("        {\n");
            stringBuilder.Append("           " + name + ".Init,\n");
            stringBuilder.Append("           " + name + ".Open,\n");
            stringBuilder.Append("           " + name + ".Close,\n");
            stringBuilder.Append("           " + name + ".Pause\n");
            stringBuilder.Append("        };\n");
            stringBuilder.Append("        return array.ToArray();\n");
            stringBuilder.Append("    }\n");

            stringBuilder.Append("\n");
            stringBuilder.Append("    public void HandleMessage(Message message)\n");
            stringBuilder.Append("    {\n");
            stringBuilder.Append("        if (data != null)\n");
            stringBuilder.Append("        {\n");
            stringBuilder.Append("            if (!message.Name.Equals(" + name + ".Pause))\n");
            stringBuilder.Append("            {\n");
            stringBuilder.Append("                if (data.IsPause)\n");
            stringBuilder.Append("                {\n");
            stringBuilder.Append("                    return;\n");
            stringBuilder.Append("                }\n");
            stringBuilder.Append("            }\n");
            stringBuilder.Append("        }\n");
            stringBuilder.Append("        switch (message.Name)\n");
            stringBuilder.Append("        {\n");
            stringBuilder.Append("            case " + name + ".Init:\n");
            stringBuilder.Append("                Init();\n");
            stringBuilder.Append("                break;\n");
            stringBuilder.Append("            case " + name + ".Open:\n");
            stringBuilder.Append("                Open();\n");
            stringBuilder.Append("                break;\n");
            stringBuilder.Append("            case " + name + ".Close:\n");
            stringBuilder.Append("                Close();\n");
            stringBuilder.Append("                break;\n");
            stringBuilder.Append("            case " + name + ".Pause:\n");
            stringBuilder.Append("                Pause((bool)message.Body);\n");
            stringBuilder.Append("                break;\n");
            stringBuilder.Append("        }\n");
            stringBuilder.Append("    }\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("    #endregion\n");
            stringBuilder.Append("\n");

            stringBuilder.Append("\n");
            stringBuilder.Append("    #region messagelogic\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("    private void Init()\n");
            stringBuilder.Append("    {\n");
            stringBuilder.Append("        data = MessageManager.Instance.GetListenerData(nameof(" + name + "Receiver)) as " + name + "Data;\n");
            stringBuilder.Append("    }\n");
            stringBuilder.Append("\n");

            stringBuilder.Append("    private void Open()\n");
            stringBuilder.Append("    {\n");
            stringBuilder.Append("    }\n");
            stringBuilder.Append("\n");

            stringBuilder.Append("    private void Close()\n");
            stringBuilder.Append("    {\n");
            stringBuilder.Append("    }\n");
            stringBuilder.Append("\n");

            stringBuilder.Append("    private void Pause(bool isPause)\n");
            stringBuilder.Append("    {\n");
            stringBuilder.Append("        data.IsPause = isPause;\n");
            stringBuilder.Append("    }\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("    #endregion\n");
            stringBuilder.Append("\n");

            stringBuilder.Append("\n");
            stringBuilder.Append("    #region logic\n");
            stringBuilder.Append("\n");
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
            stringBuilder.Append("    public bool IsPause;\n");
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
