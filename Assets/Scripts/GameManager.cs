using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject BossTank;
    public GameObject PlayerTank;
    HealtManager BossTankHealth;
    HealtManager PlayerTankHealth;
    MenuManager MenuManager;
    float TimeCheck;
    
    void Start()
    {
        //StartGame();
        BossTankHealth = BossTank.GetComponent<HealtManager>();
        PlayerTankHealth = PlayerTank.GetComponent<HealtManager>();
        MenuManager=new MenuManager();


    }

   
    void Update()
    {
        //TimeCheck +=Time.deltaTime;
        //if (TimeCheck > 2f)
        //{
        //    if (BossTankHealth.HealthAmount <= 0)
        //    {
        //        MenuManager.SceneLoader(1);
        //        BossTankHealth.HealthAmount = 1;
        //    }
        //    if (PlayerTankHealth.HealthAmount <= 0)
        //    {
        //        MenuManager.SceneLoader(3);
        //        PlayerTankHealth.HealthAmount = 1;
        //    }
        //    TimeCheck= 0;
        //}
        if (Input.GetKey(KeyCode.Escape))
        {
            MenuManager.SceneLoader(0);
        }

    }
    void StartGame()
    {
        MenuManager.SceneLoader(2);
    }
    
   

}
