using Unity.VisualScripting;
using UnityEngine;

public class Phase5: Phase
{
    public GameObject m_Boss;
    public GameObject m_BossWeapon;
    public Transform m_bossTarget;
    public Vector3 bossTargetScale = new Vector3(3f, 3f, 3f);

    public GameObject m_ObjectToMove;
    public Transform m_ObjectTarget;
    private float objectMoveTime = 4f;

    private float elapsedTimeBoss;
    private float elapsedTimeObject;

    private Vector3 bossStartPos;
    private Vector3 bossStartScale;
    private Vector3 objectStartPos;

    public Phase5(GameObject boss, GameObject weapon, Transform bossTarget,
                  GameObject obj, Transform objTarget) : base("Phase5")
    {
        m_Boss = boss;
        m_BossWeapon = weapon;
        m_bossTarget = bossTarget;
        m_ObjectToMove = obj;
        m_ObjectTarget = objTarget;
    }
    public override void OnEnter()
    {
        elapsedTimeBoss = 0f;
        elapsedTimeObject = 0f;
        m_isFinished = false;

        if (m_BossWeapon != null)
            m_BossWeapon.SetActive(false);

        if (m_Boss != null)
        {
            bossStartPos = m_Boss.transform.position;
            bossStartScale = m_Boss.transform.localScale;
        }
        if (m_ObjectToMove != null && m_ObjectTarget != null)
            objectStartPos = m_ObjectToMove.transform.position;

        Debug.Log("Phase5 Start: Boss gets bigger and moves");

    }
    public override void Execute()
    {
        if(m_isFinished) return;
        if (m_Boss != null&& m_bossTarget!=null)
        {
            elapsedTimeBoss += Time.deltaTime;
            float tBoss = Mathf.Clamp01(elapsedTimeBoss / 3.0f); 
            m_Boss.transform.position = Vector3.Lerp(bossStartPos, m_bossTarget.position, tBoss);
            m_Boss.transform.localScale = Vector3.Lerp(bossStartScale, bossTargetScale, tBoss);

        }
        if (m_ObjectToMove != null && m_ObjectTarget != null)
        {
            elapsedTimeObject += Time.deltaTime;
            float tObj = Mathf.Clamp01(elapsedTimeObject / objectMoveTime);
            m_ObjectToMove.transform.position = Vector3.Lerp(objectStartPos, m_ObjectTarget.position, tObj);
        }
       
        if ((elapsedTimeBoss >= 3.0f) && (elapsedTimeObject >= objectMoveTime))
        {
            m_ObjectToMove.SetActive(false);
            m_isFinished = true;
            Debug.Log("Phase5 Complete: Boss moves and ground went down");
        }

    }
    public override void OnExit()
    {
        Debug.Log("Phase5 Done");
    }

    public override bool IsFinished()
    {
        return m_isFinished;
    }
}
