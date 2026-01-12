using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

public class AddressablePool
{
    [Serializable]
    public class AddressableRef
    {
        public Object resource;

        public int refCount;
        
        public AddressableRef(Object resource)
        {
            this.resource = resource;
        }

    }

    private Dictionary<string, AddressableRef> _addressableRefDatas = new();
    private HashSet<string> _loadedDatas = new();
    private HashSet<string> _releaseDatas = new();
    private List<string> _resourceReleaseDatas = new();

    public async UniTask<T> LoadAddressable<T>(string key) where T : Object
    {
        if (_addressableRefDatas.ContainsKey(key) == false)
        {
            if (_loadedDatas.Contains(key) == false)
            {
                try
                {
                    _loadedDatas.Add(key);
                    var asyncOperation = Addressables.LoadAssetAsync<T>(key);

                    await UniTask.WaitUntil(() => asyncOperation.IsDone == true);

                    _loadedDatas.Remove(key);
                    if (asyncOperation.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
                    {
                        _addressableRefDatas[key] = new AddressableRef(asyncOperation.Result);
                    }
                    else
                    {
                        _addressableRefDatas[key] = null;
                        Debug.LogError($"Failed load asset: {key}");
                        return null;
                    }
                }
                catch (Exception)
                {
                    _addressableRefDatas[key] = null;
                    Debug.LogError($"Failed load asset: {key}");
                    return null;
                }
            }
            else
            {
                await UniTask.WaitUntil(() => _addressableRefDatas.ContainsKey(key) == true);
            }
        }

        if (_addressableRefDatas.ContainsKey(key) == false)
            return null;

        Interlocked.Increment(ref _addressableRefDatas[key].refCount);
        return _addressableRefDatas[key].resource as T;
    }

    public void ReleaseResource(string key, int decrementRefCount)
    {
        _resourceReleaseDatas.Add(key);
        ReleaseResource(decrementRefCount);
    }

    private void ReleaseResource(int decrementRefCount)
    {
        foreach (var key in _resourceReleaseDatas)
        {
            if (_addressableRefDatas.TryGetValue(key, out var addressable) == true)
            {
                if (addressable != null && Interlocked.Add(ref addressable.refCount, -decrementRefCount) <= 0)
                    DelayRelease(key, addressable, (60).MillisPerSecond()).Forget();
            }
        }
    }

    private async UniTaskVoid DelayRelease(string key, AddressableRef addressable, int milliseconds)
    {
        if (_releaseDatas.Contains(key) == true)
            return;

        _releaseDatas.Add(key);

        int interval = 100;
        int elapsed = 0;

        while (elapsed <= milliseconds)
        {
            await UniTask.Delay(interval);
            elapsed += interval;

            if (addressable.refCount > 0)
            {
                Debug.Log($"Release 취소: {key} ref count가 {addressable.refCount}로 증가");
                break;
            }
        }

        if (addressable.refCount <= 0)
        {
            Addressables.Release(addressable.resource);
            _addressableRefDatas.Remove(key);
            Debug.Log($"Release asset: {key}");
        }

        _releaseDatas.Remove(key);
    }
}
