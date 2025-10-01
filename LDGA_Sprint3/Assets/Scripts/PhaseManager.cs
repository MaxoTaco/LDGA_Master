using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    public GameObject boss;
    public GameObject bossWeapon;

    //phase 2

    public GameObject osiris;
    public Transform targetForOsiris;

    //phase 3

    public GameObject phase3column;
    public Transform phase3columnTarget;
    public Transform phase3BossTarget;

    //phase 4
    public GameObject phase4colummn;
    public Vector3 phase4TargetRotation;

    // Phase5
    public Transform phase5BossTarget;
    public GameObject phase5Object;
    public Transform phase5ObjectTarget;




    public List<Phase> phases=new List<Phase>();
    private int currentIndex = 0;
    
    void Start()
    {
        phases.Add(new Phase1());

        phases.Add(new Phase2(osiris,targetForOsiris));

        phases.Add(new Phase3(phase3column,phase3columnTarget,boss,phase3BossTarget));

        phases.Add(new Phase4(phase4colummn,phase4TargetRotation));

        phases.Add(new Phase5(boss, bossWeapon, phase5BossTarget,phase5Object,phase5ObjectTarget));
        if (phases.Count > 0)
        {
            phases[0].OnEnter();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (phases[currentIndex].IsFinished())
                moveNextPhase();
            else
                Debug.Log("You cannot change scene right now");
        }
        if (currentIndex < phases.Count - 1)
        {
            phases[currentIndex].Execute();
        }
    }
    void moveNextPhase()
    {
        if (currentIndex == phases.Count - 1) return;

         phases[currentIndex].OnExit();
         currentIndex++;
         phases[currentIndex].Execute();
       
    }
}
