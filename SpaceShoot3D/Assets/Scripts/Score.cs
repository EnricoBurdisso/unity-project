using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
  [SerializeField] int score = 0;
  [SerializeField] string msg = "";
  [SerializeField] Text msgText;
  [SerializeField] Text scoreText;



  void Start(){
        msgText.text = "";
  }

  void OnEnable(){
        //EventManager.onStartGame += LoadHiScore;
        EventManager.onStartGame += ResetScore;
        //EventManager.onPlayerDeath += CheckNewHiScore;
        EventManager.onPickPowerUp += ShowMsg;
        //EventManager.onScorePoint += AddScore;
        EventManager.onStartWave += AddScore;
  }

  void OnDisable(){
        //EventManager.onStartGame -= LoadHiScore;
        EventManager.onStartGame -= ResetScore;
        //EventManager.onPlayerDeath -= CheckNewHiScore;
        EventManager.onPickPowerUp -= ShowMsg;
        //EventManager.onScorePoint -= AddScore;
        EventManager.onStartWave -= AddScore;
    }



  void AddScore(){
    score++;
    DisplayScore();
    EventManager.StopWave();
  }

  void ResetScore(){
    score = 0;
    DisplayScore();
  }

  void DisplayScore(){
    scoreText.text = "Numero ondata: "+score.ToString();
  }


  void ShowMsg(string msg){
    msgText.text = msg;
        Invoke("HideMsg", 5f);
  }
    void HideMsg()
    {
        msgText.text = "";
    }
}
