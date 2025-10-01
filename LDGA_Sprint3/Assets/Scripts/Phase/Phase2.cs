using UnityEngine;

public class Phase2:Phase
{
    public GameObject m_osirisToMove;
    public Transform m_transformForOsirisToMove;
    private float m_osirisMovingTime;
    private float elapsedTime;                      // 경과 시간
    private Vector3 startPos;

    public Phase2(GameObject osirisToMove,Transform transformForOsiris) : base("Phase2")
    {
        m_osirisToMove = osirisToMove;
        m_transformForOsirisToMove = transformForOsiris;
        m_osirisMovingTime = 5.0f;

    }
    public override void OnEnter()
    {
        if (m_osirisToMove != null && m_transformForOsirisToMove != null)
        {
            startPos = m_osirisToMove.transform.position;
            elapsedTime = 0f;
            m_isFinished = false;
            Debug.Log("Phase 2 Start: Osiris moving");
        }
    }
    public override void Execute()
    {
        if (m_isFinished) return; 

        if (m_osirisToMove == null || m_transformForOsirisToMove == null || m_isFinished)
            return;

        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / m_osirisMovingTime);

        m_osirisToMove.transform.position = Vector3.Lerp(startPos, m_transformForOsirisToMove.position, t);

        if (t >= 1.0f)
        {
            m_isFinished = true;
            Debug.Log("Phase 2 Finished ");
        }
    }
    
    public override void OnExit()
    {
        Debug.Log("Phase 2 OnExit");
    }
    public override bool IsFinished()
    {
        return m_isFinished;
    }
}
