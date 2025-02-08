using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
}