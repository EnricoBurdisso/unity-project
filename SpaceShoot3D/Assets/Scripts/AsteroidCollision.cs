using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class AsteroidCollision : MonoBehaviour
{

  [SerializeField] private LifeAndShield life;
  [SerializeField] int dmgByAsteroid = 1;
  [SerializeField] int dmgByEnemy = 10;
  [SerializeField] int dmgByPlayer = 10;


  void OnCollisionEnter(Collision obj){
      if(life == null){
        return;
      }
      if(obj.gameObject.tag == "Obstacle")
        life.TakeDamage(dmgByAsteroid);
      if(obj.gameObject.tag == "Enemy")
        life.TakeDamage(dmgByEnemy);
      if(obj.gameObject.tag == "Player")
        {
            Debug.Log("Danno del player");
            life.TakeDamage(dmgByPlayer);
        }

  }

}
