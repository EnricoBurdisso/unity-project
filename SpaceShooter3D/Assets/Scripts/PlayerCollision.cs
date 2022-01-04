using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerCollision : MonoBehaviour
{
  [SerializeField] LifeAndShield life;
  [SerializeField] int dmgAsteroid = 1;
  [SerializeField] int dmgEnemy = 10;

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


}
