using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeAndShield : MonoBehaviour
{
    public static int maxHealth = 100,
                         curHealth;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    public void test()
    {
        Debug.Log("test");
    }

    public void TakeDamage(int dmg = 1){
        curHealth -= dmg;
        if(curHealth < 0)
            curHealth = 0;

        //EventManager.TakeDamage(curHealth/(float)maxHealth);
        if(gameObject.tag == "Player")
          EventManager.TakeDamage(curHealth/(float)maxHealth);

        if(curHealth < 1){
            //curHealth = 0;
            GetComponent<Explosion>().BlowUp();

            Destroy(gameObject);
            //Debug.Log("PLAYER DIED");
        }

    }

}
