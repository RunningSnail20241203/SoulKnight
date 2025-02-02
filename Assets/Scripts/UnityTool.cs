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
        return (from Transform tran in obj.GetComponentInChildren<Transform>()
            where tran.name == name && tran.GetComponent<T>() != null
            select tran.GetComponent<T>()).FirstOrDefault();
    }
}