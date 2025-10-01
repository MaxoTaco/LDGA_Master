using JetBrains.Annotations;
using UnityEngine;

public class Phase3:Phase
{

    public GameObject m_columnObject;         
    public GameObject m_Boss;                 
    public Transform m_destinationForBoss;     

    private float timeToMoveColumn = 5.0f;     
    private float timeToMoveBoss = 1.0f;       

    private float elapsedTimeColumn;
    private float elapsedTimeBoss;

    private float columnStartY;
    private Vector3 bossStartPos;
    private Vector3 bossTargetPos;

    public Phase3(GameObject columnObject, GameObject boss, Transform bossTarget)
        : base("Phase3")
    {
        m_columnObject = columnObject;
        m_Boss = boss;
        m_destinationForBoss = bossTarget;
    }

    public override void OnEnter()
    {
        elapsedTimeColumn = 0f;
        elapsedTimeBoss = 0f;
        m_isFinished = false;

        if (m_columnObject != null)
            columnStartY = m_columnObject.transform.position.y;

        if (m_Boss != null && m_destinationForBoss != null)
        {
            bossStartPos = m_Boss.transform.position;
            bossTargetPos = m_destinationForBoss.position;
        }

        Debug.Log("Phase3 ");
    }

    public override void Execute()
    {
        if (m_isFinished) return;

     
        if (elapsedTimeColumn < timeToMoveColumn && m_columnObject != null)
        {
            elapsedTimeColumn += Time.deltaTime;
            float tCol = Mathf.Clamp01(elapsedTimeColumn / timeToMoveColumn);

            Vector3 pos = m_columnObject.transform.position;
            pos.y = Mathf.Lerp(columnStartY, 1f, tCol);
            m_columnObject.transform.position = pos;
        }

   
        if (elapsedTimeBoss < timeToMoveBoss && m_Boss != null && m_destinationForBoss != null)
        {
            elapsedTimeBoss += Time.deltaTime;
            float tBoss = Mathf.Clamp01(elapsedTimeBoss / timeToMoveBoss);
            m_Boss.transform.position = Vector3.Lerp(bossStartPos, bossTargetPos, tBoss);
        }


        if (elapsedTimeColumn >= timeToMoveColumn && elapsedTimeBoss >= timeToMoveBoss)
        {
            m_isFinished = true;
            Debug.Log("Phase3 Over");
        }
    }

    public override void OnExit()
    {
        Debug.Log("Phase3 Exit");
    }

    public override bool IsFinished()
    {
        return m_isFinished;
    }

}
