using UnityEngine;

public class Phase4:Phase
{
    public GameObject m_column;
    public Vector3 m_targetEulerAngles;
    private float m_timeToRotate;
    private float elapsedTime;

    private Quaternion startRotation;
    private Quaternion targetRotation;

    public Phase4(GameObject column, Vector3 targetEuler) : base("Phase4")
    {
        m_column = column;
        m_targetEulerAngles = targetEuler;
    }

    public override void OnEnter()
    {
        elapsedTime = 0f;
        m_isFinished = false;

        if (m_column != null)
        {
            startRotation = m_column.transform.rotation;
            targetRotation = Quaternion.Euler(m_targetEulerAngles);
        }

        Debug.Log("Phase4 Start: Column Getting ready to fall");
    }

    public override void Execute()
    {
        if (m_isFinished || m_column == null) return;

        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / m_timeToRotate);

        m_column.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);

        if (t >= 1.0f)
        {
            m_isFinished = true;
            Debug.Log("Phase4 Complete: Column fell");
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


