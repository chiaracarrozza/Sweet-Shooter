using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : NPCStatable
{
    private EnemyController smartagent;
   
    public NPCStatable DoState(EnemyController smartagent)
    {
        this.smartagent = smartagent;

        Chasing();

        if (!this.smartagent.CheckEngagement())
        {
            return this.smartagent.Return;
        }
        else
        {
            return this.smartagent.currentstate;
        }
    }

    private void Chasing()
    {
        if (smartagent.OnPatrol)
        {
            smartagent.lastPatrolPos = smartagent.transform.position;
        }
        smartagent.OnPatrol=false;
        smartagent.nav.SetDestination(smartagent.mark.position);
    }
    
}
