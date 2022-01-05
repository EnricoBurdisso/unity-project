using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private List<GameObject> prefabPowerUp=new List<GameObject>();
    private bool canTake;
    [SerializeField] private int reg=10;

    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Player"))
        {
            PickPowerUp(col.transform);
        }
    }

    void PickPowerUp(Transform player)
    {
        if (transform.CompareTag("PowerUpAll") && canTake==true) // recupero tutta la salute
        {
            Debug.Log("VERDE");
            //recupero tutta la salute
            int diff = LifeAndShield.maxHealth - LifeAndShield.curHealth;
            player.GetComponent<LifeAndShield>().TakeDamage(-diff);
            Destroy(gameObject);
            //Debug.Log("cur: " + LifeAndShield.curHealth);
            
            //Debug.Log("cur: "+LifeAndShield.curHealth);
            
        }else if (transform.CompareTag("PowerUpTot") && canTake==true) //recupero un tot di vita
        {
            Debug.Log("BLU");
            //recupero un tot di salute
            player.GetComponent<LifeAndShield>().TakeDamage(-reg);
            Debug.Log("cur: " + LifeAndShield.curHealth);
            Destroy(gameObject);
        }
        //add powerup effect
        //prefabPowerUp = powerupspawner.GetPrefabListPowerUp();
        //Debug.Log(prefabPowerUp.Count);
        //destroy powerup
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LifeAndShield.curHealth < LifeAndShield.maxHealth)
        {
            canTake = true;
        }
        else
        {
            canTake = false;
        }
    }
}
