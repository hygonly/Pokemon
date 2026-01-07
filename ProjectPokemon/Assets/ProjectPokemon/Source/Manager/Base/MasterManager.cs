using UnityEngine;

public interface IMasterManager
{
    Behaviour GetBehaviour();
    GameObject GetObject();
}

public class MasterManager : MonoBehaviour, IMasterManager
{
    public Behaviour GetBehaviour() { return this; }

    public GameObject GetObject() { return gameObject; }
}
