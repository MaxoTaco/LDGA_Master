using Unity.VisualScripting;
using UnityEngine;

public class Phase5: Phase
{
    public GameObject m_Boss;
    public GameObject m_BossWeapon;
    public Transform m_bossTarget;
    public Vector3 bossTargetScale = new Vector3(3f, 3f, 3f);

    public GameObject m_ObjectToMove;
    private float objectMoveTime = 4f; 

    private float elapsedTimeBoss;
    private float elapsedTimeObject;

    private Vector3 bossStartPos;
    private Vector3 bossStartScale;
    private float objectStartY;

    public Phase5(GameObject boss, GameObject weapon, Transform bossTarget,
                  GameObject obj) : base("Phase5")
    {
        m_Boss = boss;
        m_BossWeapon = weapon;
        m_bossTarget = bossTarget;
        m_ObjectToMove = obj;
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

        if (m_ObjectToMove != null)
            objectStartY = m_ObjectToMove.transform.position.y;

        Debug.Log("Phase5 Start");
    }

    public override void Execute()
    {
        if (m_isFinished) return;

     
        if (m_Boss != null && m_bossTarget != null)
        {
            Debug.Log("Phase5 object not null");
            elapsedTimeBoss += Time.deltaTime;
            float tBoss = Mathf.Clamp01(elapsedTimeBoss / 3f);
            m_Boss.transform.position = Vector3.Lerp(bossStartPos, m_bossTarget.position, tBoss);
            m_Boss.transform.localScale = Vector3.Lerp(bossStartScale, bossTargetScale, tBoss);
        }

       
        if (m_ObjectToMove != null)
        {
            Debug.Log("Phase5 object not null");
            elapsedTimeObject += Time.deltaTime;
            float tObj = Mathf.Clamp01(elapsedTimeObject / objectMoveTime);

            Vector3 pos = m_ObjectToMove.transform.position;
            pos.y = Mathf.Lerp(objectStartY, -1f, tObj);
            m_ObjectToMove.transform.position = pos;
        }

        // Phase 완료 조건
        if ((elapsedTimeBoss >= 3f) && (elapsedTimeObject >= objectMoveTime))
        {
            m_isFinished = true;
            Debug.Log("Phase5 Complete");
        }
    }

    public override void OnExit()
    {
        Debug.Log("Phase5 End");
    }

    public override bool IsFinished()
    {
        return m_isFinished;
    }
}
