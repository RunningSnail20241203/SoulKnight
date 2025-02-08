using System.Linq;
using UnityEngine;

public class UnityTool
{
    private static UnityTool _instance;

    public static UnityTool Instance
    {
        get { return _instance ??= new UnityTool(); }
    }

    public T FindComponentFromChildren<T>(GameObject obj, string name, bool includeActive) where T : Component
    {
        return (from Transform tran in obj.GetComponentsInChildren<Transform>(includeActive)
            where tran.name == name && tran.GetComponent<T>() != null
            select tran.GetComponent<T>()).FirstOrDefault();
    }

    public T AddComponentForChildren<T>(GameObject obj, string name, bool includeActive) where T : Component
    {
        var tran = FindTransformFromChildren(obj, name, includeActive);
        return tran.gameObject.AddComponent<T>();
    }

    public Transform FindTransformFromChildren(GameObject obj, string name, bool includeActive)
    {
        return (from Transform tran in obj.GetComponentsInChildren<Transform>(includeActive)
            where tran.name == name
            select tran).FirstOrDefault();
    }

    public GameObject FindGameObjectFromChildren(GameObject obj, string name, bool includeActive)
    {
        var tran = FindTransformFromChildren(obj, name, includeActive);
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
}