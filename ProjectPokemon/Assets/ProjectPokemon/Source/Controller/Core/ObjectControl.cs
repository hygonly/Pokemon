using UniRx;
using UnityEngine;

public abstract class ObjectControl : MonoBehaviour
{
    protected ReactiveProperty<Defines.ObjectState> _objectState = new ReactiveProperty<Defines.ObjectState>();
    protected Defines.Direction _dir;

    private void Awake()
    {
        Initialized();    
    }

    public abstract void Initialized();

    protected void MoveObject(Vector2 targetPos, float moveSpeed)
    {
        Vector2 ownerPos = transform.position;
        var dirToTarget = targetPos - ownerPos;

        var movePos = dirToTarget * moveSpeed;
        var moveTranslate = movePos * Config.GAME_TICK;
        transform.Translate(moveTranslate);
    }
}