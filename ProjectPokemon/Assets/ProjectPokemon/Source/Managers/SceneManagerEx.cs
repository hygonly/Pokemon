using Cysharp.Text;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Defines;

public class SceneManagerEx : SlaveManager
{
    public BaseScene CurrentScene => _currentScene;
    public Defines.SceneType GetCurrentSceneType => _currentScene.SceneType;

    public bool MoveScene { get; private set; } = false;

    private BaseScene _currentScene;
    private Scene _sceneInstance;


    public async UniTask LoadSceneAsync(Defines.SceneType sceneType)
    {
        var handle = Managers.Resource.LoadScene(sceneType);
        MoveScene = true;

        while (handle.IsDone == false)
        {
            Debug.Log($"씬 로딩 중: {sceneType} {handle.PercentComplete}");
            await UniTask.Yield();
        }

        Debug.Log("씬 로딩 완료");

        if (handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            _sceneInstance = handle.Result.Scene;

        var releaseHandle = Resources.UnloadUnusedAssets();
        while (releaseHandle.isDone == false)
        {
            Debug.Log("사용하지 않는 에셋 릴리즈 중");
            await UniTask.Yield();
        }

        Debug.Log("릴리즈 완료");
        MoveScene = false;
    }

    public void RegisterScene(BaseScene scene)
    {
        _currentScene = scene;
    }

    public void UnregisterScene(Defines.SceneType sceneType)
    {
        string loadKey = ZString.Concat(Config.ScenePath, "/", sceneType.ToString(), ".unity");
        Managers.Resource.Release(loadKey);
    }
}