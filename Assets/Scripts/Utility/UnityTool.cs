using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utility
{
    public class UnityTool
    {
        private static UnityTool _instance;

        public static UnityTool Instance
        {
            get { return _instance ??= new UnityTool(); }
        }

        public T FindComponentFromChildren<T>(GameObject obj, string name, bool includeInactive = true) where T : Component
        {
            return (from Transform tran in obj.GetComponentsInChildren<Transform>(includeInactive)
                where tran.name == name && tran.GetComponent<T>() != null
                select tran.GetComponent<T>()).FirstOrDefault();
        }

        public T AddComponentForChildren<T>(GameObject obj, string name, bool includeInactive = true) where T : Component
        {
            var tran = FindTransformFromChildren(obj, name, includeInactive);
            return tran.gameObject.AddComponent<T>();
        }

        public Transform FindTransformFromChildren(GameObject obj, string name, bool includeInactive = true)
        {
            return (from Transform tran in obj.GetComponentsInChildren<Transform>(includeInactive)
                where tran.name == name
                select tran).FirstOrDefault();
        }

        public GameObject FindGameObjectFromChildren(GameObject obj, string name, bool includeInactive = true)
        {
            var tran = FindTransformFromChildren(obj, name, includeInactive);
            return tran?.gameObject;
        }

        public T FindComponentInScene<T>(string name) where T : Component
        {
            var obj = GameObject.Find(name);
            return obj?.GetComponent<T>();
        }

        public GameObject FindGameObjectInScene(string name)
        {
            return GameObject.Find(name);
        }

        public bool IsGenericType(Type type, Type generic)
        {
            // 检查输入参数是否为 null
            if (type == null || generic == null)
            {
                return false;
            }

            // 首先检查当前类型是否直接匹配泛型定义
            if (IsGeneric(type))
            {
                return true;
            }

            // 存储已经检查过的接口，避免重复检查
            var checkedInterfaces = new HashSet<Type>();

            // 遍历类型的继承链
            while (type != null && type != typeof(object))
            {
                // 获取当前类型实现的所有接口
                var interfaces = type.GetInterfaces();
                if (interfaces.Any(iface => checkedInterfaces.Add(iface) && IsGeneric(iface)))
                {
                    return true;
                }

                // 移动到基类继续检查
                type = type.BaseType;
            }

            return false;

            bool IsGeneric(Type t)
            {
                // 检查是否为泛型类型且泛型定义是否匹配
                return t.IsGenericType && t.GetGenericTypeDefinition() == generic;
            }
        }

        public void WriteDataToList<T>(List<T> list, TextAsset textAsset) where T : new()
        {
            if (textAsset == null) return;

            list.Clear();
            var t = typeof(T);
            var text = textAsset.text.Replace("\r", "");
            var rows = text.Split("\n");
            var fieldNames = rows[0].Split(",");
            for (var i = 1; i < rows.Length; i++)
            {
                var row = rows[i];
                if (string.IsNullOrEmpty(row))continue;

                var obj = Activator.CreateInstance<T>();
                var columns = row.Split(",");
                for (var j = 0; j < columns.Length; j++)
                {
                    if(string.IsNullOrEmpty(columns[j]) || string.IsNullOrEmpty(fieldNames[j])) continue;
                    var fieldInfo = t.GetField(fieldNames[j]);
                    if(fieldInfo == null) continue;
                    fieldInfo.SetValue(obj, ConvertType(columns[j], fieldInfo.FieldType));
                }
                list.Add(obj);
            }

            return;
            object ConvertType(string s, Type type)
            {
                try
                {
                    // 处理布尔值
                    if (bool.TryParse(s, out var boolResult))
                    {
                        return boolResult;
                    }
                    // 处理枚举类型
                    if (type.IsEnum)
                    {
                        return Enum.Parse(type, s);
                    }
                    // 处理泛型列表类型
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        var elementType = type.GetGenericArguments()[0];
                        var obj = Activator.CreateInstance(type) as IList;
                        var paramLst = s.Split(',');
                        foreach (var param in paramLst)
                        {
                            var convertedParam = ConvertType(param.Trim(), elementType);
                            obj?.Add(convertedParam);
                        }
                        return obj;
                    }
                    // 其他类型使用 Convert.ChangeType 进行转换
                    return Convert.ChangeType(s, type);
                }
                catch (Exception ex)
                {
                    // 处理异常，可根据实际需求进行日志记录或其他操作
                    Console.WriteLine($"Type conversion failed: {ex.Message}");
                    return null;
                }
            }
        }
    }
}