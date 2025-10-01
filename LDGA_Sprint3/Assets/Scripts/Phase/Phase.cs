using System;
using UnityEngine;

public abstract class Phase
{
    protected string m_nameOfPhase;
    protected bool m_isFinished;
    public Phase(string name)
    {
        m_isFinished = false;
        m_nameOfPhase = name;
    }
    public virtual void OnEnter() { }
    public virtual void Execute() { }
    public virtual void OnExit() { }
    public abstract bool IsFinished();

}
