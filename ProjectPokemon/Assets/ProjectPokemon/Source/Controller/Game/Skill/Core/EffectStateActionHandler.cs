using System;
using UnityEngine;

public abstract class EffectStateActionHandler
{
    protected Defines.EffectActionState mEffectActionState;

    public virtual bool IsActionUpdate => mEffectActionState == Defines.EffectActionState.Update;
    public virtual bool IsActionFinished => mEffectActionState == Defines.EffectActionState.Finish;

    public virtual void Reset()
    {
        mEffectActionState = Defines.EffectActionState.Enter;
    }

    protected void TransitionToNextState() => ++mEffectActionState;

    protected abstract void ProcessSkillState(Action onEnter, Action onUpdate, Action onExit);
    
    public void SetActionStatus(Defines.EffectActionState state)
    {
        switch (state)
        {
            case Defines.EffectActionState.Enter:
                break;
            case Defines.EffectActionState.Update:
                break;
            case Defines.EffectActionState.Exit:
            case Defines.EffectActionState.Finish:
                break;
        }

        mEffectActionState = state;
    }

    public virtual bool Return()
    {
        switch (mEffectActionState)
        {
            case Defines.EffectActionState.Exit:
            case Defines.EffectActionState.Finish:
                return false;
        }

        return true;
    }
}
