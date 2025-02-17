using System;
using System.Threading.Tasks;
using Item.Effect;
using Singleton;
using Object = UnityEngine.Object;

namespace Factory
{
    public class EffectFactory : Singleton<EffectFactory>
    {
        public async Task<T> GetEffect<T>() where T: AbstractEffectBoom
        {
            var prefab = await ResourceFactory.Instance.GetEffect(typeof(T).Name);
            var obj = Object.Instantiate(prefab);
            return Activator.CreateInstance(typeof(T),  new object[]{obj} ) as T;
        }
    }
}