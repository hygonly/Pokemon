using UnityEngine;

public partial class Managers : MasterManager
{
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static JsonDataManager JsonData { get { return Instance._jsonData; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }

    private ResourceManager _resource;
    private JsonDataManager _jsonData;
    private SceneManagerEx _scene;
}
