using System.Linq;
using UnityEngine;

public class UnityTool
{
    private static UnityTool _instance;

    public static UnityTool Instance
    {
        get { return _instance ??= new UnityTool(); }
    }

    public T GetComponentFromChildren<T>(GameObject obj, string name) where T : Component
    {
        return (from Transform tran in obj.GetComponentsInChildren<Transform>()
            where tran.name == name && tran.GetComponent<T>() != null
            select tran.GetComponent<T>()).FirstOrDefault();
    }

    public T AddComponentForChildren<T>(GameObject obj, string name) where T : Component
    {
        var tran = GetTransformFromChildren(obj, name);
        return tran.gameObject.AddComponent<T>();
    }

    public Transform GetTransformFromChildren(GameObject obj, string name)
    {
        return (from Transform tran in obj.GetComponentsInChildren<Transform>()
            where tran.name == name
            select tran).FirstOrDefault();
            
    }
}