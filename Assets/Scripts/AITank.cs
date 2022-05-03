using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITank : Tanks
{
    public GameObject TargetPlayer;
    public NavMeshAgent AIagent { get { return GetComponent<NavMeshAgent>(); } }
    public Animator AIFSM { get { return GetComponent<Animator>(); } }
    float Distance = 0f;
    float DelayedFire = 0;
    public Transform[] PatrolPoints;
    Vector3[] PatrolPointsPos;
    public int index;
    float WayPointDistance;
    float TheTime;




     void Start()
    {
        PatrolPointsPos=new Vector3[PatrolPoints.Length];
        for (int i = 0; i < PatrolPoints.Length; i++)
        {
            PatrolPointsPos[i]=PatrolPoints[i].transform.position;

        }
        index = 0;
        AIagent.SetDestination(PatrolPointsPos[index]);
    }
    void FixedUpdate()
    {
        WayPointDistance = Vector3.Distance(transform.position, PatrolPointsPos[index]);
        Distance=Vector3.Distance(transform.position, TargetPlayer.transform.position);
        AIFSM.SetFloat("Distance", Distance);
        AIFSM.SetFloat("WaypointDistance", WayPointDistance);
        if ((TheTime += Time.deltaTime) > 1f/5f)
        {
            StartCoroutine(MoveEffectSlowly(1));
            TheTime = 0f;
        }
        
        



    }
    public override void Fire()
    {
        StartCoroutine(MoveAITurrret());
        
        if ((DelayedFire += Time.deltaTime) > 2f) { 
        Transform TurretTransform = Turret.GetComponent<Transform>();
        var bomb = Instantiate(BombPrefab, BombSpawner.position, Quaternion.identity);
        bomb.AddForce(TurretTransform.forward * BombSpeed);
        Debug.Log("AI Fired");
        DelayedFire = 0;
        }       
    }
    

    protected override void MoveTank(){}
    public IEnumerator MoveAITurrret()
    {
        while (Vector3.Angle(Turret.transform.forward, (TargetPlayer.transform.position - transform.position)) > 5f)
        {
            Turret.transform.Rotate(transform.up, 1f*Time.deltaTime);
            yield return null;
        }
    }

    public override void MoveEffect(float moveAxis){
        Track.mainTextureOffset += new Vector2(moveAxis, 0);
    }
    

    public void Chase()
    {
        Debug.Log("AI is Chasing");
        AIagent.SetDestination(TargetPlayer.transform.position);
    }
    public void StopChase()
    {
        AIagent.SetDestination(transform.position);
    }
    
    public void BackToPatrolPoints()
    {
        switch (index)
        {
            case 0: 
                index = 1; 
                break;
            case 1: 
                index = 2; 
                break;
            case 2: 
                index = 3; 
                break;
            case 3: 
                index = 0; 
                break;
        }
        AIagent.SetDestination(PatrolPointsPos[index]);
        Debug.Log(index + "index");

    }
    public void FixDistance()
    {
        AIFSM.SetFloat("WaypointDistance", 0f);

    }

    IEnumerator MoveEffectSlowly(float moveAxis)
    {
        
        this.MoveEffect(moveAxis);
        if(Track.mainTextureOffset.x > 1000)
        {
            Track.mainTextureOffset = new Vector2(0,0);
        }
        yield return null;
    }


}
