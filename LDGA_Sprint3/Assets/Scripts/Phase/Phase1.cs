using UnityEngine;

public class Phase1: Phase
{
    public Phase1():base("Phase 1")
    {

    }
    public override void OnEnter()
    {
        Debug.Log("Enter Phase 1");
    }
    public override void Execute()
    {
        Debug.Log("Phase 1: Nothing happens here");
    }
    public override void OnExit()
    {
        Debug.Log("Phase 1 End");
        m_isFinished = true;
    }
    public override bool IsFinished()
    {
        return m_isFinished;
    }
    
    
}
