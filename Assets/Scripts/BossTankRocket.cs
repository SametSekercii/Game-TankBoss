using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankRocket : BombController
{
     
    
    

    public void Start()
    {
        damage = 50;
        radius = 30f;
        ExplosionPower = 10000f;
    }
    public void OnCollisionEnter(Collision collision)
    {
        BombSoundEffect();
        HealtManager CollisionHealth = collision.gameObject.GetComponent<HealtManager>();
        BombSound.PlayOneShot(BombSound.clip);
        CreateExpolisonEffect(ExplosionPower);
        
        Destroy(gameObject,1f);
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
