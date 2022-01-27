using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerCollision : MonoBehaviour
{
  [SerializeField] LifeAndShield life;
  [SerializeField] int dmgAsteroid = 1;
  [SerializeField] int dmgEnemy = 10;
    [SerializeField] private int tot = 10;

    private string tagPowerUp = "PowerUp";
    private bool canTakePowerUp = false;
    private MeshRenderer[] meshRenderers;

    private void Awake()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    void OnCollisionEnter(Collision obj){
      if(life == null){
        return;
      }
      //metti EventManager
      if(obj.gameObject.tag == "Obstacle"){
            Debug.Log("Collosione con asteroide");
            life.TakeDamage(dmgAsteroid);
      }
      if(obj.gameObject.tag == "Enemy"){
        life.TakeDamage(dmgEnemy);
      }
  }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.transform.tag.Contains(tagPowerUp))
        {
            PickPowerUp(obj.transform);
        }
    }

    void PickPowerUp(Transform powerup)
    {
        if (powerup.CompareTag(tagPowerUp + "All") && canTakePowerUp == true) //recupero tutta la salute
        {
            int diff = life.getMaxHealth() - life.getCurHealth();
            life.TakeDamage(-diff);
            EventManager.PickPowerUp("Cura Totale");
            Destroy(powerup.gameObject);
            Debug.Log("cur: " + life.getCurHealth());
        }
        else if (powerup.CompareTag(tagPowerUp + "Tot") && canTakePowerUp == true) //recupero tot saute
        {
            if(life.getCurHealth() <= life.getMaxHealth() - tot)
            {

                life.TakeDamage(-tot);
            }
            else
            {
                life.TakeDamage(-(life.getMaxHealth() - life.getCurHealth()));
            }
            EventManager.PickPowerUp("Cura Parziale");
            Destroy(powerup.gameObject);
            Debug.Log("cur: " + life.getCurHealth());
        }else if(powerup.CompareTag(tagPowerUp + "Invulnerability")) //ottengo invulnerabilita'
        {
            StartCoroutine(life.BecomeTemporarilyInvincible(meshRenderers));
            Destroy(powerup.gameObject);
        }
    }

    
    private void Update()
    {
        if(life.getCurHealth() < life.getMaxHealth())
        {
            canTakePowerUp = true;
        }
        else
        {
            canTakePowerUp = false;
        }
    }


}
