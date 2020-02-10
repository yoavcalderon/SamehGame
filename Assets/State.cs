using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Character character;

    public abstract void Tick();

    public virtual void onStateEnter() { }
    public virtual void onStateExit() { }
    public virtual bool Gate() { return true; }

    public State(Character character)
    {
        this.character = character;
    }

}
