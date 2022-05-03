using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public Transform playerTurret;
    Vector3 DiffVector;
    

    void Start()
    {
        playerTurret=FindObjectOfType<PlayerTank>().transform;
        DiffVector = playerTurret.position - transform.position;
        
    }
    void LateUpdate()
    {
        
        transform.position = playerTurret.position - DiffVector;
        

       

    }


}
