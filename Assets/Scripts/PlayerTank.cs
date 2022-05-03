using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : Tanks
{

    float PlayerTankMoveSpeed = 75f;
    

    void Start()
    {
        
    }
   

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad6))
        {
            StartCoroutine(MoveTurret(TurretRotationAngle));
            
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            StartCoroutine(MoveTurret(-TurretRotationAngle));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();

        }
        MoveTank();
        //Debug.DrawLine(transform.position, transform.position+transform.forward*20f,Color.blue);

    }

    protected override void MoveTank()
    {
        float MoveAxis = Input.GetAxis("Vertical");
        float RotateAxis = Input.GetAxis("Horizontal");
        rb.MovePosition(transform.position+transform.forward*Time.deltaTime* PlayerTankMoveSpeed * MoveAxis);
        rb.MoveRotation(transform.rotation*Quaternion.Euler(transform.up*RotateAxis*TanksRotationSpeed*Time.deltaTime));
        MoveEffect(MoveAxis);
    }

    protected IEnumerator MoveTurret(float TurretRotationAngle)
    {
        Transform TurretTransform =Turret.GetComponent<Transform>();
        TurretTransform.Rotate(transform.up, TurretRotationAngle);
        yield return null;
    }

    public override void Fire()
    {
        Transform TurretTransform = Turret.GetComponent<Transform>();
        var bomb = Instantiate(BombPrefab, BombSpawner.position, Quaternion.identity);
        bomb.AddForce(TurretTransform.forward * BombSpeed + BombSpawner.up * 25f); ;
        
    }

    public override void MoveEffect(float moveAxis)
    {
        Track.mainTextureOffset +=new Vector2(moveAxis, 0);
    }
    
}
