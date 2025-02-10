using System.Collections;
using Model;
using UnityEngine;

namespace Mono
{
    public class LoadingData : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return new WaitUntil(() => ModelContainer.Instance.IsInited);
            Destroy(gameObject);
        }
    }
}