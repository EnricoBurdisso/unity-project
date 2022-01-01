using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void StartGameDelegate();
    public static event StartGameDelegate onStartGame;

    public delegate void TakeDamageDelegate(float amt);
    public static event TakeDamageDelegate onTakeDamage;

    public static void StartGame(){
      if(onStartGame != null){
        //Debug.Log("START");
        onStartGame();
      }
    }

    public static void TakeDamage(float percent)
    {
      Debug.Log("Take Damage: " + percent);

        if (onTakeDamage != null)
        {
            onTakeDamage(percent);
        }
    }
}
