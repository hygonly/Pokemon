using UnityEngine;

public class BaseScene : MonoBehaviour
{
    public Defines.SceneType SceneType => _sceneType;

    [SerializeField] protected Defines.SceneType _sceneType;

    protected bool _init;

    private void Awake()
    {
        Init();
    }

    protected virtual bool Init()
    {
        if (_init == true)
            return false;

        Managers.Scene.RegisterScene(this);
        return true;
    }

    public virtual void Clear()
    {
        if (_init == false)
            return;

        _init = false;
        Managers.Scene.UnregisterScene(_sceneType);
    }
}