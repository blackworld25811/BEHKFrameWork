using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
//using ZXing;
//using ZXing.QrCode;
//using ExcelDataReader;

namespace BEHKFrameWork.Utility
{
    public class Utility
    {
        //public static Texture2D CreatQRCode(string content, int width, int height)
        //{
        //    Texture2D texture2D = new Texture2D(width, height);
        //    QrCodeEncodingOptions qrCodeEncodingOptions = new QrCodeEncodingOptions();
        //    qrCodeEncodingOptions.CharacterSet = "UTF-8";
        //    qrCodeEncodingOptions.Width = width;
        //    qrCodeEncodingOptions.Height = height;
        //    qrCodeEncodingOptions.Margin = 2;

        //    BarcodeWriter barcodeWriter = new BarcodeWriter();
        //    barcodeWriter.Format = BarcodeFormat.QR_CODE;
        //    barcodeWriter.Options = qrCodeEncodingOptions;

        //    var color32 = barcodeWriter.Write(content);
        //    texture2D.SetPixels32(color32);
        //    texture2D.Apply();

        //    return texture2D;
        //}

        public static void ChangeAnimationClip(Animator animator, AnimationClip animationClip, string clipName)
        {
            AnimatorOverrideController animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
            animator.runtimeAnimatorController = animatorOverrideController;
            animatorOverrideController[clipName] = animationClip;
        }

        public static void ShareBone(SkinnedMeshRenderer skinnedMeshRenderer, GameObject target)
        {
            Transform[] newBones = new Transform[skinnedMeshRenderer.bones.Length];
            for (int i = 0; i < skinnedMeshRenderer.bones.GetLength(0); ++i)
            {
                GameObject bone = skinnedMeshRenderer.bones[i].gameObject;
                newBones[i] = FindChildRecursion(target.transform, bone.name);
            }
            skinnedMeshRenderer.bones = newBones;
        }

        private static Transform FindChildRecursion(Transform transform, string name)
        {
            foreach (Transform child in transform)
            {
                if (child.name == name)
                {
                    return child;
                }
                else
                {
                    Transform ret = FindChildRecursion(child, name);
                    if (ret != null)
                        return ret;
                }
            }
            return null;
        }

        public static string GetTime(int number)
        {
            int hour = number / (60 * 60);
            int minute = (number - hour * 60 * 60) / 60;
            int second = number - hour * 60 * 60 - minute * 60;
            string hourString = hour < 10 ? "0" + hour : "" + hour;
            string minuteString = minute < 10 ? "0" + minute : "" + minute;
            string secondString = second < 10 ? "0" + second : "" + second;
            string time = hourString + ":" + minuteString + ":" + secondString;
            return time;
        }

        //public static DataSet ReadExcel(string excelPath)
        //{
        //    FileStream fileStream = File.Open(excelPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        //    IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
        //    DataSet dataset = excelDataReader.AsDataSet();
        //    return dataset;
        //}

        public static List<string[]> ReadExcelSheet(DataSet dataSet, string sheetName)
        {
            List<string[]> result = new List<string[]>();
            DataRowCollection dataRow = dataSet.Tables[sheetName].Rows;
            for (int i = 1; i < dataRow.Count; i++)
            {
                DataRow datarow = dataRow[i];
                string[] temp = new string[datarow.ItemArray.Length];
                for (int j = 0; j < datarow.ItemArray.Length; j++)
                {
                    temp[j] = datarow.ItemArray[j].ToString();
                }
                result.Add(temp);
            }
            return result;
        }

        public static void ClearAllChild(Transform father, bool isImmediate)
        {
            if (isImmediate)
            {
                int count = father.childCount;
                for (int i = 0; i < count; i++)
                {
                    Object.DestroyImmediate(father.GetChild(0).gameObject);
                }
            }
            else
            {
                for (int i = 0; i < father.childCount; i++)
                {
                    Object.Destroy(father.GetChild(i).gameObject);
                }
            }
        }
    }
}
