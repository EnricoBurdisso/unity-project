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

    public void HitTaken(Vector3 pos){
      GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
      Destroy(go, 6f);

      Debug.Log("Taking Damage");

      if(life == null)
        return;

      life.TakeDamage();

    }

    void OnCollisionEnter(Collision collision){
      foreach(ContactPoint contact in collision.contacts)
        HitTaken(contact.point);
    }




   public void BlowUp()
    {
        Debug.Log("BOOM");
        //summon particle effect
        Instantiate(blowUp,transform.position,Quaternion.identity);
        //destroy self
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
    }


}
