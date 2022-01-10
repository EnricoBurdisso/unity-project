using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeAndShieldUI : MonoBehaviour
{
    [SerializeField]  Text txt;


    void Awake(){
      txt.text = "Life: " + 100 + " %";
    }


    void OnEnable(){
      EventManager.onTakeDamage += UpdateLifeDisplay;
    }

    void OnDisable(){
      EventManager.onTakeDamage -= UpdateLifeDisplay;
    }


    void UpdateLifeDisplay(float percent){
      //Debug.Log("DisplayText: " + percent);

      
        txt.text = "Life: " + percent * 100 + " %";
    }
}
