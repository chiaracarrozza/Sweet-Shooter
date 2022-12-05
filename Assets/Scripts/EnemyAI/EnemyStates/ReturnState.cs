using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnState : NPCStatable
{
    EnemyController smartagent;

    public NPCStatable DoState(EnemyController smartagent)
    {
        this.smartagent = smartagent;

        Returning();

        if (this.smartagent.CheckEngagement())
        {
            return this.smartagent.Chase;
        }
        if (this.smartagent.OnPatrol)
        {
            return this.smartagent.Patrol;
        }
        return this.smartagent.currentstate;
    }

    private void Returning()
    {
        smartagent.nav.SetDestination(smartagent.lastPatrolPos);
        if (Vector3.Distance(smartagent.transform.position, smartagent.lastPatrolPos) <= 1.0f)
        {
            smartagent.OnPatrol = true;
            float distanceA=Vector3.Distance(smartagent.lastPatrolPos,smartagent.pointA.position);
            float distanceB=Vector3.Distance(smartagent.lastPatrolPos, smartagent.pointB.position);

            if (distanceA <= distanceB)
                smartagent.nav.SetDestination(smartagent.pointA.position);
            else
                smartagent.nav.SetDestination(smartagent.pointB.position);
        }
    }
}
