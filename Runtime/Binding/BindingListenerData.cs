using System;
using System.Reflection;
using BEHKFrameWork.Utility;
using BEHKFrameWork.Message;
using System.Collections.Generic;

namespace BEHKFrameWork.Binding
{
    internal class BindingListenerData : Singleton<BindingListenerData>
    {
        /// <summary>
        /// the IDate reflection information,content property or field name and attribute
        /// </summary>
        private readonly Dictionary<IData, List<DataReflectionInformation>> dataReflectionInformationDictionary;

        /// <summary>
        /// record ui comopnent key's attribute
        /// </summary>
        private readonly Dictionary<string, BindingAttribute> keyAttributeDictionary;


        public BindingListenerData()
        {
            dataReflectionInformationDictionary = new Dictionary<IData, List<DataReflectionInformation>>();
            keyAttributeDictionary = new Dictionary<string, BindingAttribute>();
        }

        /// <summary>
        /// get one IDate all reflection information,about propertyInfo,fieldInof and attribute 
        /// </summary>
        /// <param name="data"></param>
        public void Binding(IData data)
        {
            // already hava List<DataReflectionInformation>
            if (dataReflectionInformationDictionary.ContainsKey(data))
            {
                return;
            }
            Type type = data.GetType();
            // check all of property
            PropertyInfo[] propertyInfos = type.GetProperties();

            foreach (var propertyInfo in propertyInfos)
            {
                BindingAttribute bindingAttribute = propertyInfo.GetCustomAttribute<BindingAttribute>();
                if (bindingAttribute == null)
                {
                    // only message logic
                    bindingAttribute = new BindingAttribute(null);
                }
                AddDataReflictionInformation(data, propertyInfo.Name, bindingAttribute);

                bindingAttribute.Object = data;
                bindingAttribute.PropertyInfo = propertyInfo;
                bindingAttribute.OldFieldValue = propertyInfo.GetValue(data);
                // only ui comoponet binding
                if (bindingAttribute.Key != null)
                {
                    // class name + attribute name,keep id only
                    keyAttributeDictionary.TryAdd(type.Name + bindingAttribute.Key, bindingAttribute);
                }
                BindingUpdate.Instance.AddBindingAttributes(bindingAttribute);
            }
            // check all of field
            FieldInfo[] fieldInfos = type.GetFields();
            foreach (var fieldInfo in fieldInfos)
            {
                BindingAttribute bindingAttribute = fieldInfo.GetCustomAttribute<BindingAttribute>();
                if (bindingAttribute == null)
                {
                    bindingAttribute = new BindingAttribute(null);
                }
                AddDataReflictionInformation(data, fieldInfo.Name, bindingAttribute);

                bindingAttribute.Object = data;
                bindingAttribute.FieldInfo = fieldInfo;
                bindingAttribute.OldFieldValue = fieldInfo.GetValue(data);
                if (bindingAttribute.Key != null)
                {
                    keyAttributeDictionary.TryAdd(bindingAttribute.Key, bindingAttribute);
                }
                BindingUpdate.Instance.AddBindingAttributes(bindingAttribute);
            }
        }

        /// <summary>
        /// create or refresh dataReflectionInformationList
        /// </summary>
        /// <param name="data"></param>
        /// <param name="name"></param>
        /// property or field name
        /// <param name="bindingAttribute"></param>
        private void AddDataReflictionInformation(IData data, string name, BindingAttribute bindingAttribute)
        {
            List<DataReflectionInformation> dataReflectionInformationList;
            // create a new reflection information
            DataReflectionInformation dataReflectionInformation = new DataReflectionInformation(name, bindingAttribute);
            // if not add IData reflection information
            if (dataReflectionInformationDictionary.TryGetValue(data, out dataReflectionInformationList) == false)
            {
                dataReflectionInformationList = new List<DataReflectionInformation>();
                dataReflectionInformationDictionary.TryAdd(data, dataReflectionInformationList);
            }
            if (dataReflectionInformationList.Contains(dataReflectionInformation) == false)
            {
                dataReflectionInformationList.Add(dataReflectionInformation);
            }
        }

        /// <summary>
        /// get a attribute of the key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public BindingAttribute GetBindingAttribute(string key)
        {
            if (keyAttributeDictionary.TryGetValue(key, out BindingAttribute value))
            {
                return value;
            }
            return null;
        }

        /// <summary>
        ///  get a IDataReflectionInformation of the IData
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<DataReflectionInformation> GetDataReflectionInformation(IData data)
        {
            if (dataReflectionInformationDictionary.TryGetValue(data, out List<DataReflectionInformation> value))
            {
                return value;
            }
            return null;
        }
    }
}

