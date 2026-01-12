using UnityEngine;

public interface ISalveManager
{
    IMasterManager GetMaster();

    void RegisterMaster(IMasterManager master);
    void UnregisterMaster();
}

public class SlaveManager : ISalveManager
{
    public IMasterManager GetMaster() { return _master; }

    private IMasterManager _master;

    protected bool _init;

    public void RegisterMaster(IMasterManager master)
    {
        _master = master;
    }

    public void UnregisterMaster()
    {
        if (_master == null)
            return;

        _master = null;
    }
}
