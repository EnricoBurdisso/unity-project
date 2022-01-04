using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  [SerializeField] LifeAndShield life;
  [SerializeField] int dmgAsteroid = 1;
  [SerializeField] int dmgEnemy = 10;


  void PlayerHitByAsteroid(){
    if(life == null){
      return;
    }
    Debug.Log("Taking Damage by Asteroid");
    life.TakeDamage(dmgAsteroid);
  }

  void PlayerHitByEnemy(){
    if(life == null){
      return;
    }
    Debug.Log("Taking Damage by Enemy");
    life.TakeDamage(dmgEnemy);
  }

  void OnCollisionEnter(Collision obj){

      //metti EventManager
      if(obj.gameObject.tag == "Obstacle"){
        //EventManager.TakeDamage(20);
        PlayerHitByAsteroid();
      }
      if(obj.gameObject.tag == "Enemy"){
        PlayerHitByEnemy();
      }
  }


}
