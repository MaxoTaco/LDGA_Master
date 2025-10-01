using JetBrains.Annotations;
using UnityEngine;

public class Phase3:Phase
{

    public GameObject m_columnObject;          
    public GameObject m_Boss;                
    public Transform m_destinationForColumn;  
    public Transform m_destinationForBoss;    

    private float timeToMoveColumn = 2.0f;    
    private float timeToMoveBoss = 5.0f;      

    private float elapsedTimeColumn;
    private float elapsedTimeBoss;

    private Vector3 columnStartPos;
    private Vector3 columnTargetPos;
    private Vector3 bossStartPos;
    private Vector3 bossTargetPos;

    public Phase3(GameObject columnObject, Transform columnDestination, GameObject boss, Transform bossDestination)
        : base("Phase3")
    {
        m_columnObject = columnObject;
        m_destinationForColumn = columnDestination;
        m_Boss = boss;
        m_destinationForBoss = bossDestination;
    }

    public override void OnEnter()
    {
        elapsedTimeColumn = 0f;
        elapsedTimeBoss = 0f;
        m_isFinished = false;

       
        if (m_columnObject != null && m_destinationForColumn != null)
        {
            columnStartPos = m_columnObject.transform.position;
            columnTargetPos = m_destinationForColumn.position;
        }

       
        if (m_Boss != null && m_destinationForBoss != null)
        {
            bossStartPos = m_Boss.transform.position;
            bossTargetPos = m_destinationForBoss.position;
        }

        Debug.Log("Phase3 Start: Column and Boss move ready");
    }

    public override void Execute()
    {
        if (m_isFinished) return;

        // Column Moving
        if (elapsedTimeColumn < timeToMoveColumn && m_columnObject != null && m_destinationForColumn != null)
        {
            elapsedTimeColumn += Time.deltaTime;
            float tCol = Mathf.Clamp01(elapsedTimeColumn / timeToMoveColumn);
            m_columnObject.transform.position = Vector3.Lerp(columnStartPos, columnTargetPos, tCol);
        }

        // Boss Moving
        if (elapsedTimeBoss < timeToMoveBoss && m_Boss != null && m_destinationForBoss != null)
        {
            elapsedTimeBoss += Time.deltaTime;
            float tBoss = Mathf.Clamp01(elapsedTimeBoss / timeToMoveBoss);
            m_Boss.transform.position = Vector3.Lerp(bossStartPos, bossTargetPos, tBoss);
        }

        // Phase over when it is done
        if (elapsedTimeColumn >= timeToMoveColumn && elapsedTimeBoss >= timeToMoveBoss)
        {
            m_isFinished = true;
            Debug.Log("Phase3 Complete Boss and columns moved");
        }
    }

    public override void OnExit()
    {
        Debug.Log("Phase3 Over");
    }

    public override bool IsFinished()
    {
        return m_isFinished;
    }

}
