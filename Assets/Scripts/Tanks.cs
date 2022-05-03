using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tanks : MonoBehaviour
{
    public Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    protected float TanksMoveSpeed = 5f;
    protected float TanksRotationSpeed = 240f;
    protected float TurretRotationAngle = 0.5f;
    public GameObject Turret;
    public Rigidbody BombPrefab;
    public Transform BombSpawner;
    protected float BombSpeed = 50000f;
    public Material Track;


    void FixedUpdate()
    {
        
        


    }

    protected abstract void MoveTank();
    
    public abstract void MoveEffect(float moveAxis);
    public abstract void Fire();

}
