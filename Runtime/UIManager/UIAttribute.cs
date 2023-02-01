using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BEHKFrameWork.UIManager
{
    [AttributeUsage(AttributeTargets.Field)]
    public class UIAttribute : Attribute
    {
        private string name;

        /// <summary>
        /// the GameObject's UI full name
        /// </summary>
        public string Name { get => name; set => name = value; }

        public UIAttribute(string name)
        {
            Name = name;
        }
    }
}
