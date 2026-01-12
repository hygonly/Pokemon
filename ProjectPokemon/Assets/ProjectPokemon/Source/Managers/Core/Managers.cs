using UnityEngine;

public partial class Managers : MasterManager
{
    public static Managers Instance 
    { 
        get 
        {
            if (_instance == null)
            {
                _instance = Create();
                _instance.Init();
                _init = true;
            }

            return _instance; 
        } 
    }

    private static Managers _instance;

    private static bool _init;

    private static Managers Create()
    {
        GameObject go = GameObject.Find("@Managers");
        if (go == null)
        {
            go = new GameObject("@Managers");
            go.AddComponent<Managers>();
        }

        DontDestroyOnLoad(go);
        return go.GetComponent<Managers>();
    }

    private void Init()
    {
        _resource = new ResourceManager();
        _jsonData = new JsonDataManager();
        _scene = new SceneManagerEx();

        _resource.RegisterMaster(this);
        _jsonData.RegisterMaster(this);
        _scene.RegisterMaster(this);
    }

}
