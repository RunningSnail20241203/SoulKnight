using System;
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
        private const string AnimatorPath = "Animation/Character/Player/{0}/{1}.controller";
        private const string DataPath = "Data/{0}.asset";
        private readonly Dictionary<string, object> _resourceCache = new();
        private readonly Dictionary<string, TaskCompletionSource<object>> _loadingTasks = new();


        public async Task<GameObject> GetWeapon(string name)
        {
            var path = string.Format(WeaponPath, name);
            return await GetResource<GameObject>(path);
        }

        public async Task<RuntimeAnimatorController> GetAnimatorController(string playerName, string skinName)
        {
            var path = string.Format(AnimatorPath, playerName, skinName);
            return await GetResource<RuntimeAnimatorController>(path);
        }

        public async Task<T> GetData<T>(string name) where T : ScriptableObject
        {
            var path = string.Format(DataPath, name);
            return await GetResource<T>(path);
        }

        private async Task<T> GetResource<T>(string path) where T : class
        {
            // 检查缓存
            if (_resourceCache.TryGetValue(path, out var value))
            {
                if (value is T result)
                {
                    return result;
                }

                throw new InvalidCastException(
                    $"Cached resource at path {path} cannot be cast to type {typeof(T).Name}.");
            }

            // 检查是否正在加载
            if (_loadingTasks.TryGetValue(path, out var tcs))
            {
                var taskResult = await tcs.Task;
                if (taskResult is T taskResultAsT)
                {
                    return taskResultAsT;
                }

                throw new InvalidCastException(
                    $"Loaded resource at path {path} cannot be cast to type {typeof(T).Name}.");
            }

            // 开始加载
            var newTcs = new TaskCompletionSource<object>();
            _loadingTasks[path] = newTcs;

            try
            {
                var retObj = await Addressables.LoadAssetAsync<T>(path).Task;
                _resourceCache[path] = retObj;
                newTcs.SetResult(retObj);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to load resource at path {path}: {ex.Message}");
                newTcs.SetException(ex);
            }
            finally
            {
                _loadingTasks.Remove(path);
            }

            var finalResult = await newTcs.Task;
            if (finalResult is T finalResultAsT)
            {
                return finalResultAsT;
            }

            throw new InvalidCastException($"Loaded resource at path {path} cannot be cast to type {typeof(T).Name}.");
        }
    }
}