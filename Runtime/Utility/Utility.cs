using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace BEHKFrameWork.Utility
{
    public class Utility
    {
        public static void WriteFile(string fullPath, string content)
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
                FileStream file = new FileStream(fullPath, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(file, Encoding.UTF8);
                streamWriter.Write(content);
                streamWriter.Flush();
                streamWriter.Close();
                file.Close();
            }
        }

        public static string RemoveStringBlank(string content)
        {
            return Regex.Replace(content, @"\s", "");
        }

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

        public static string GetCallClassName()
        {
            string name = null;
            MethodBase method = new System.Diagnostics.StackTrace().GetFrame(3).GetMethod();
            name = method.ReflectedType.FullName;
            // fix async function
            if (name.Contains("Async"))
            {
                method = new System.Diagnostics.StackTrace().GetFrame(4).GetMethod();
                name = method.ReflectedType.FullName;
            }
            return name;
        }
    }
}
