using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemyCollision : MonoBehaviour
{
  [SerializeField] LifeAndShield life;
  [SerializeField] int dmgAsteroid = 1;
  [SerializeField] int dmgPlayer = 10;

  void OnCollisionEnter(Collision obj){
      if(life == null){
        return;
      }

      switch(obj.gameObject.tag){
        case "Obstacle":
          life.TakeDamage(dmgAsteroid);
          break;

        case "Player":
          life.TakeDamage(dmgPlayer);
          break;

        default:
            Debug.Log("Enemy was hit by Unkwnown");
            break;
      }

  }
}
