using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BEHKFrameWork.UIManager
{
    [AttributeUsage(AttributeTargets.Field)]
    public class UIAttribute : Attribute
    {
        private string instanceID;

        /// <summary>
        /// the GameObject's GetInstanceID
        /// </summary>
        public string InstanceID { get => instanceID; set => instanceID = value; }

        public UIAttribute(string instanceID)
        {
            InstanceID = instanceID;
        }
    }
}
