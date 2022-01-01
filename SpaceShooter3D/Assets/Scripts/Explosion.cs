using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject blowUp;
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
