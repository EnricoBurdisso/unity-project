using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeAndShield : MonoBehaviour
{
    [SerializeField] int maxHealth = 10,
                         curHealth;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }


    public void TakeDamage(int dmg = 1){
        curHealth -= dmg;

        if(curHealth < 0)
            curHealth = 0;

        EventManager.TakeDamage(curHealth/(float)maxHealth);

        if(curHealth < 1){
            //curHealth = 0;
            GetComponent<Explosion>().BlowUp();
            //Debug.Log("PLAYER DIED");
        }

    }

}
