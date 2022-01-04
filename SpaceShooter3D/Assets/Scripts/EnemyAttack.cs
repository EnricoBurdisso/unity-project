using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
  [SerializeField] Transform target;
  [SerializeField] Laser laser;

  Vector3 hitPosition;

  void Update(){
    if(!FindTarget())
      return;
    InFront();
    HaveLineOfSight();
    if(InFront() && HaveLineOfSight()){
      FireLaser();
    }
  }

  bool InFront(){
    Vector3 directionToTarget = transform.position - target.position;
    float angle = Vector3.Angle(transform.forward, directionToTarget);

    if(Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270){
      Debug.DrawLine(transform.position, target.position, Color.green);
      return true;
    }
    Debug.DrawLine(transform.position, target.position, Color.red);
    return false;
  }


  bool HaveLineOfSight(){
    RaycastHit hit;

    Vector3 direction = target.position - transform.position;

    if(Physics.Raycast(laser.transform.position, direction, out hit, laser.Distance)){

      Debug.Log("Enemy hit: " + hit.transform.tag);
      Debug.DrawLine(laser.transform.position, hit.point);

      if(hit.transform.CompareTag("Player")){

        Debug.DrawRay(laser.transform.position, direction, Color.blue);
        hitPosition = hit.transform.position;

        return true;
      }
    }

    return false;
  }

  bool FindTarget(){
    if(target == null){
      GameObject temp = GameObject.FindGameObjectWithTag("Player");
      if(temp != null)
        target = temp.transform;
    }

    if(target == null)
      return false;
    return true;
  }

  void FireLaser(){
    Debug.Log("Fire Laser");
    laser.FireLaser(hitPosition,target);
  }
}
