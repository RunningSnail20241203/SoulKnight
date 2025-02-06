using System.Collections.Generic;
using System.Threading.Tasks;
using Singleton;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Factory
{
    public class ResourceFactory : Singleton<ResourceFactory>
    {
        private const string WeaponPath = "Weapon/PlayerWeapon/{0}.prefab";
        private readonly Dictionary<string, GameObject> _weaponCache = new();
        private readonly HashSet<string> _weaponLoading = new();

        public async Task<GameObject> GetWeapon(string name)
        {
            var path = string.Format(WeaponPath, name);
            if (_weaponCache.TryGetValue(path, out var obj))
            {
                return await Task.FromResult(obj);
            }

            // todo Task的优化逻辑，防止重复加载，后续验证是否有效 
            if (!_weaponLoading.Add(path))
            {
                return await Task.Run(() =>
                {
                    while (!_weaponCache.ContainsKey(path))
                    {
                    }

                    return _weaponCache[path];
                });
            }

            var retObj = await Addressables.LoadAssetAsync<GameObject>(path).Task;
            _weaponLoading.Remove(path);
            _weaponCache.Add(path, retObj);
            return retObj;
        }
    }
}