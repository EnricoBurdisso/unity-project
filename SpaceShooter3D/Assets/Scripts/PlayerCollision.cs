using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  [SerializeField] LifeAndShield life;
  [SerializeField] int dmgAsteroid = 1;
  void PlayerHitByAsteroid(){

    if(life == null){
      return;
    }


    Debug.Log("Taking Damage");
    life.TakeDamage(dmgAsteroid);
  }

  void OnCollisionEnter(Collision obj){

      //metti EventManager
      if(obj.gameObject.tag == "Obstacle"){
        //EventManager.TakeDamage(20);
        PlayerHitByAsteroid();
      }
  }


}
