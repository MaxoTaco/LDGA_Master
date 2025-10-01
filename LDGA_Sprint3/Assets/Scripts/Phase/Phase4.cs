using UnityEngine;

public class Phase4:Phase
{
    public GameObject m_column;
    public Transform m_targetTransform;
    private float moveTime = 2f;
    private float rotateTime = 1.5f;

    private float elapsedMove;
    private float elapsedRotate;

    private Vector3 startPos;
    private Quaternion startRot;
    private Quaternion targetRot;

    public Phase4(GameObject column, Transform targetTransform) : base("Phase4")
    {
        m_column = column;
        m_targetTransform = targetTransform;
    }

    public override void OnEnter()
    {
        elapsedMove = 0f;
        elapsedRotate = 0f;
        m_isFinished = false;

        if (m_column != null && m_targetTransform != null)
        {
            startPos = m_column.transform.position;
            startRot = m_column.transform.rotation;

          
            Vector3 dir = m_targetTransform.position - m_column.transform.position;
            dir.y = 0; 
            if (dir == Vector3.zero) dir = Vector3.forward;

            
            targetRot = Quaternion.LookRotation(dir) * Quaternion.Euler(90f, 0f, 0f);
        }

        Debug.Log("Phase4 Start");
    }

    public override void Execute()
    {
        if (m_isFinished || m_column == null || m_targetTransform == null) return;

        if (elapsedRotate < rotateTime)
        {
            elapsedRotate += Time.deltaTime;
            float tRotate = Mathf.Clamp01(elapsedRotate / rotateTime);

            
            Vector3 dir = m_targetTransform.position - m_column.transform.position;
            dir.y = 0; 
            if (dir == Vector3.zero) dir = Vector3.forward;

            Quaternion targetRot = Quaternion.LookRotation(dir) * Quaternion.Euler(90f, 0f, 0f);
            m_column.transform.rotation = Quaternion.Slerp(startRot, targetRot, tRotate);
        }


        // Phase ¿Ï·á
        if (elapsedRotate >= rotateTime)
        {
            m_isFinished = true;
            Debug.Log("Phase4 Complete ");
        }
    }

    public override void OnExit()
    {
        Debug.Log("Phase4 Exit");
    }

    public override bool IsFinished()
    {
        return m_isFinished;
    }
}


