using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class CoroutinePool : MonoBehaviour
    {
        public static CoroutinePool Instance
        {
            get
            {
                if (_instance != null) return _instance;

                var obj = UnityTool.Instance.FindGameObjectInScene(nameof(CoroutinePool));
                _instance = obj?.GetComponent<CoroutinePool>() ??
                            new GameObject(nameof(CoroutinePool), typeof(CoroutinePool)).GetComponent<CoroutinePool>();
                return _instance;
            }
        }

        public void StartCoroutine(object obj, IEnumerator enumerator)
        {
            if (_coroutineDic.TryGetValue(obj, out var coroutines))
            {
                coroutines.Add(StartCoroutine(enumerator));
            }
            else
            {
                _coroutineDic.Add(obj, new List<Coroutine> {StartCoroutine(enumerator)});
            }
        }

        public void StopCoroutine(object obj)
        {
            if (!_coroutineDic.TryGetValue(obj, out var coroutines)) return;
            
            foreach (var coroutine in coroutines)
            {
                StopCoroutine(coroutine);
            }
            coroutines.Clear();
        }

        #region Private

        private static CoroutinePool _instance;
        private Dictionary<object, List<Coroutine>> _coroutineDic = new();

        #endregion
    }
}