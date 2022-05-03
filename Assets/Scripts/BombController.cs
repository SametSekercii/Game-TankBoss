using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BombController : MonoBehaviour
{
    protected int damage;
    protected float radius;
    protected float ExplosionPower;
    public GameObject ExplosionEffect;
    protected MenuManager MenuManager;
    protected bool isdead;
    protected AudioSource BombSound { get { return GetComponent<AudioSource>(); }}



    protected abstract void CreateExpolisonEffect(float power);
    protected abstract void BombSoundEffect();
    






}

