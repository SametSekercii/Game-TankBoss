using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealtManager : MonoBehaviour
{
    Transform CameraPos;
    public Text HealthAmountText;
    public int HealthAmount;
    public Image HealthBar;
    public float maxHealthAmount;
    public Transform HealthUI;
    Vector3 LookDirectionVector;
    public GameObject HealEffectPreFab;
    float TimeForHealEffect;
    bool IsDead;





    void Start()
    {
        CameraPos = Camera.main.transform;

        maxHealthAmount = HealthAmount;
        //Debug.Log("max Health=" + maxHealthAmount);
        IsDead = false;





    }

    
    void Update()
    {
        LookDirectionVector = (HealthUI.position-CameraPos.position).normalized;
        Quaternion LookRotation=Quaternion.LookRotation(LookDirectionVector);
        HealthUI.rotation = LookRotation;
        //Debug.Log("Healths=" + HealthAmount);
        if (HealthAmount <= 0)
        {
            Destroy(gameObject,2f);
            //Debug.Log("ifloop");

        }
        DeathCheck();
        if (IsDead==true)
        {
            if (gameObject.name.Equals("PlayerTank"))
            {
                SceneManager.LoadScene(3);

            }
            if (gameObject.name.Equals("AITank1"))
            {
                SceneManager.LoadScene(1);

            }
        }

      

    }

    public void TakeDamage(int Damage) 
    {
        StartCoroutine(TakeDamageSlowly(Damage));

    }

    public IEnumerator TakeDamageSlowly(int Damage)
    {
        for(int i = 0; i < Damage/5; i++)
        {
            if (HealthAmount < Damage)
            {
                //Debug.Log("(HealthAmount < Damage");

                while (HealthAmount!=0)
                {
                    HealthAmount--;
                    HealthAmountText.text = HealthAmount.ToString();
                    HealthBar.fillAmount = HealthAmount / maxHealthAmount;
                    if (HealthAmount == 0) break;
                    


                }
                yield return null;

            }
            HealthAmount -= 5;
            HealthAmountText.text = HealthAmount.ToString();
            HealthBar.fillAmount = HealthAmount / maxHealthAmount;
            
            yield return null;

        }

    }
   public void OnTriggerStay(Collider other)
    {

        string TriggerName = other.gameObject.name;
        if (TriggerName.Equals("HealingPad"))
            {
            
            if ((TimeForHealEffect += Time.deltaTime) > 1f)
            {
                var HealEffect = Instantiate(HealEffectPreFab, other.transform.position, transform.rotation);
                Destroy(HealEffect.gameObject, 1f);
                TimeForHealEffect = 0;
            }
            
            //Debug.Log("JoinedHealingPad");
            StartCoroutine(Heal());
            
        }

    }
   

    public IEnumerator Heal()
    {
        float ExistHealth = maxHealthAmount - HealthAmount;
        for(float i=0; i < ExistHealth; i+=0.1f)
        {
            while (HealthAmount != maxHealthAmount)
            {
                HealthAmount++;
                HealthAmountText.text = HealthAmount.ToString();
                HealthBar.fillAmount = HealthAmount / maxHealthAmount;
                yield return null;
            }

        }
        
    }
    public void DeathCheck()
    {
        if (HealthAmount <= 0)
        {
            IsDead = true;
        }

    }
    
}
