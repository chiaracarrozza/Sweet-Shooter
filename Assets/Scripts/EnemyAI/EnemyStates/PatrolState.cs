using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : NPCStatable
{
    EnemyController smartagent;
   
    public NPCStatable DoState(EnemyController smartagent)
    {
        this.smartagent = smartagent;

        Patrolling();

        if (this.smartagent.CheckEngagement())
        {
            return this.smartagent.Chase;
        }
        else
        {
            return this.smartagent.currentstate;
        }

    }

    private void Patrolling()
    {
        if(Vector3.Distance(smartagent.transform.position,smartagent.pointA.position) <= 5.0f)
        {
            smartagent.nav.SetDestination(smartagent.pointB.position);
        }
        if (Vector3.Distance(smartagent.transform.position, smartagent.pointB.position) <= 5.0f)
        {
            smartagent.nav.SetDestination(smartagent.pointA.position);
        }
    }
   
}
