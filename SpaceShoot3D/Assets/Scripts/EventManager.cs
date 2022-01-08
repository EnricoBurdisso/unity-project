using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void StartGameDelegate();
    public static event StartGameDelegate onStartGame;

    public delegate void PlayerDeathDelegate();
    public static event PlayerDeathDelegate onPlayerDeath;

    public delegate void TakeDamageDelegate(float amt);
    public static event TakeDamageDelegate onTakeDamage;

    public delegate void ScorePointDelegate(int amt);
    public static event ScorePointDelegate onScorePoint;

    public delegate void StartWaveDelegate();
    public static event StartWaveDelegate onStartWave;

    public delegate void StopWaveDelegate();
    public static event StopWaveDelegate onStopWave;

    public delegate void PickPowerUpDelegate(string msg);
    public static event PickPowerUpDelegate onPickPowerUp;

    public static void StartGame(){
      if(onStartGame != null)
        onStartGame();
    }

    public static void TakeDamage(float percent){
      if(onTakeDamage != null)
        onTakeDamage(percent);
    }

    public static void StartWave()
    {
        if (onStartWave != null)
            onStartWave();
    }

    public static void StopWave()
    {
        if (onStopWave != null)
            onStopWave();
    }

    public static void PickPowerUp(string msg)
    {
        if (onPickPowerUp != null)
            onPickPowerUp(msg);
    }
}
