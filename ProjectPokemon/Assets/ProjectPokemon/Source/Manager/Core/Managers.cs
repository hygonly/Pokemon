using UnityEngine;

public partial class Managers : MasterManager
{
    public static Managers Instance 
    { 
        get 
        {
            if (_instance == null)
            {
                GameObject go = GameObject.Find("@Managers");
                if (go == null)
                {
                    go = new GameObject("@Managers");
                    go.AddComponent<Managers>();
                }

                _instance = go.GetComponent<Managers>();
                DontDestroyOnLoad(go);

                _init = true;
            }

            return _instance; 
        } 
    }

    private static Managers _instance;

    private static bool _init;

}
