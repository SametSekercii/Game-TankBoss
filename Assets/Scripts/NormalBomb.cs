using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBomb : BombController
{

   
    
    

    public void Start()
    {
        damage = 45;
        radius = 10f;
        ExplosionPower = 2000f;
        BombSoundEffect();
        Destroy(gameObject, 1f);
    }
    public void OnCollisionEnter(Collision collision)
    {
        
        CreateExpolisonEffect(ExplosionPower);
        HealtManager CollisionHealth = collision.gameObject.GetComponent<HealtManager>();
        if (CollisionHealth == null) { return; }
        CollisionHealth.TakeDamage(damage);
        
       




    }
     protected override void CreateExpolisonEffect(float power)
    {
        var Explosion = Instantiate(ExplosionEffect, transform.position, transform.rotation);
        Collider[] EffectedObjects = Physics.OverlapSphere(transform.position, radius);
        foreach (var Objects in EffectedObjects)
        {
            Rigidbody ObjectsRigidBody = Objects.GetComponent<Rigidbody>();
            if (ObjectsRigidBody != null)
            {
                ObjectsRigidBody.AddExplosionForce(power, transform.position, radius);

            }

        }
        Destroy(Explosion.gameObject, 1f);

    }

    protected override void BombSoundEffect()
    {
        this.BombSound.Play();
    }

    
}
