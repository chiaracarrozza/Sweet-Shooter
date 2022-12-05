using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NPCStatable currentstate;

    public ChaseState Chase= new ChaseState();
    public PatrolState Patrol= new PatrolState();
    public ReturnState Return= new ReturnState();

    [HideInInspector] public NavMeshAgent nav;

    [HideInInspector] public bool OnPatrol;

    [HideInInspector] public Vector3 lastPatrolPos;

    [SerializeField] public Transform pointA;
    [SerializeField] public Transform pointB;

    [SerializeField] public Transform mark;

    [SerializeField] float detectionDist;
    [SerializeField] float fieldOfVision;

     private float detectioncos;


    // Start is called before the first frame update
    void Start()
    {
        OnPatrol = true;

        nav= GetComponent<NavMeshAgent>();

        float halfFoV=fieldOfVision / 2.0f;

        detectioncos = Mathf.Cos(Mathf.Deg2Rad * halfFoV);

        lastPatrolPos = transform.position;

        currentstate = Patrol;

    }

    // Update is called once per frame
    void Update()
    {
        currentstate = currentstate.DoState(this);
    }

    public bool CheckEngagement()
    {
        float distance=Vector3.Distance(transform.position,mark.position);

        Vector3 vecToMark= Vector3.Normalize(mark.position-transform.position);

        float dotProd =Vector3.Dot(transform.forward,vecToMark);

        if((dotProd>= detectioncos) && (distance<= detectionDist))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
