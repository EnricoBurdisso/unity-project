using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
  LineRenderer lineRenderer;
  Light laserLight;

  [SerializeField] private float laserOff = 0.5f;
  [SerializeField] private float maxDistanceShoot = 10f; // boh
  [SerializeField] private float fireDelay = 2f;

  private bool canFire;


  private void Awake()
  {
      //mTransform = GetComponent<Transform>();
      lineRenderer = GetComponent<LineRenderer>();
      laserLight = GetComponent<Light>();
  }

  void Start()
  {
      lineRenderer.enabled = false;
      laserLight.enabled = false;
      canFire = true;
  }

  void Update()
  {
      //FireLaser(transform.forward * maxDistanceShoot);
      Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxDistanceShoot, Color.yellow );
  }


  public void FireLaser(Vector3 targetPosition, Transform target = null){
      if(canFire){
        if(target != null)
          SpawnExplosion(targetPosition, target);

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, targetPosition);
        lineRenderer.enabled = true;
        laserLight.enabled = true;
        canFire = false;
        Invoke("LaserOff", laserOff);
        Invoke("CanFire", fireDelay);
      }


  }


  public void FireLaser(){
    Vector3 pos = CastRay();
    FireLaser(pos);
  }

  void LaserOff()
  {
      lineRenderer.enabled = false;
      laserLight.enabled = false;
      //canFire = true;

  }
  void CanFire()
  {
      canFire = true;
  }


  public float Distance{
    get{ return maxDistanceShoot;}
  }

  Vector3 CastRay(){

      RaycastHit hit;
      Vector3 fwd = transform.TransformDirection(Vector3.forward) * maxDistanceShoot;

      if (Physics.Raycast(transform.position, fwd, out hit)){
            Debug.Log("We hit: " + hit.transform.name + " with tag: " + hit.transform.tag);

            Explosion temp = hit.transform.GetComponent<Explosion>();
            if(temp != null)
              temp.HitTaken(hit.point);
            //per poter collegare asteroide colpito con effetti particellari


            SpawnExplosion(hit.point, hit.transform);

            return hit.point;
      }else{
        Debug.Log("We missed..");
        return transform.position +(transform.forward * maxDistanceShoot);

      }

  }

  void SpawnExplosion(Vector3 hitPosition, Transform target){

        Explosion temp = target.GetComponent<Explosion>();
        if(temp != null)
            temp.HitTaken(hitPosition);

  }
}
