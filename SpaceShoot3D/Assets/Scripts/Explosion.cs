using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject blowUp;
    [SerializeField] LifeAndShield life;
    [SerializeField] GameObject explosion;

    [SerializeField] int dmgByLaser = 20;


    public void HitTaken(Vector3 pos){
      GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
      Destroy(go, 6f);

      if(life == null)
        return;

      life.TakeDamage(dmgByLaser);
    }

    void OnCollisionEnter(Collision c){
      foreach(ContactPoint contact in c.contacts){
        HitTaken(contact.point);
      }
    }


    public void BlowUp()
    {
        Debug.Log("BOOM: "+transform);
        //summon particle effect
        GameObject tmp = Instantiate(blowUp, transform.position, Quaternion.identity) as GameObject;
        Destroy(tmp, 3f);

        if (gameObject.tag == "Obstacle") 
            GetComponent<PowerUp>().InstantiatePowerUp(); 

        if(gameObject.tag == "Player"){
            //EventManager.PlayerDeath();
            Destroy(gameObject);
          SceneManager.LoadScene("GameOver");
        }

        /*
        if(gameObject.tag == "Enemy"){
          //Debug.Log("Punti guadagnati");
          EventManager.EnemyDeath();
          //EventManager.ScorePoint(points);
        }
        */
        Destroy(gameObject);
    }


}
