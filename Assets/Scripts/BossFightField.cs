using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightField : MonoBehaviour
{
    
    AudioSource BossFightMusic { get { return GetComponent<AudioSource>(); } }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("EnteredSomething");
        if (other.gameObject.name.Equals("PlayerTank"))
        {
            Debug.Log("onBossField");
            PlayFightMusic();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("PlayerTank"))
        {
            StopFightMusic();
        }
    }
    public void PlayFightMusic()
    {
        BossFightMusic.Play();

    }
    public void StopFightMusic()
    {
        BossFightMusic.Pause();


    }
}
