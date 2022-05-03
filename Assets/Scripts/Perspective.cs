using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : Sense
{
    public Transform TargetPlayer;
    float maxCheckDistance;
    float PerspectiveAngle;
    Animator FsmAI;
    public Transform AIEye;
    float Distance;


    public override void InitialiazeSense()
    {
        PerspectiveAngle = 100;
        maxCheckDistance = 150;
        FsmAI = GetComponent<Animator>();
    }

    public override void UpdateSense()
    {
        Vector3 DirectionV=(TargetPlayer.transform.position- AIEye.position).normalized;
        Distance = Vector3.Distance(transform.position, TargetPlayer.transform.position);
        //Debug.DrawLine(AIEye.position, DirectionV*maxCheckDistance, Color.white);
        float angle = Vector3.Angle(DirectionV,AIEye.forward);

        if (Distance < 50)
        {
            FsmAI.SetBool("CanSee", true);
            return;
        } 
            




        //Debug.Log("angle= "+angle);
        Debug.DrawLine(AIEye.position, AIEye.position+AIEye.forward*maxCheckDistance,Color.blue);

        Debug.DrawLine(AIEye.position, DirectionV*maxCheckDistance+AIEye.position,Color.red);
        if (angle < PerspectiveAngle / 2f)
        {
            Ray DirectionRay =new Ray(AIEye.position,DirectionV);

            
            if(Physics.Raycast(DirectionRay,out RaycastHit hitInfo, maxCheckDistance))
            {
                Debug.DrawLine(AIEye.position,DirectionV+AIEye.position,Color.green);
                //Debug.Log("Ray Hit Something");
                string nameInfo = hitInfo.transform.name;
                Debug.Log("Object" + nameInfo);
                if (nameInfo.Equals("PlayerTank"))
                {
                    FsmAI.SetBool("CanSee", true);
                }
                else
                {
                    FsmAI.SetBool("CanSee", false);
                }

            }
            

        }
        else
        {
            FsmAI.SetBool("CanSee", false);
        }
    }
}
