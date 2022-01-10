using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Wave{
  public string waveName;
  public int numEnemies;

  //volendo si possono mettere nemici di diverso tipo (es. boss etc)
  public GameObject[] typeOfEnemies;
  public float spawnInterval;
}

public class WaveManager : MonoBehaviour
{

  public Wave[] waves;
  public Transform[] spawnPoints;

  //private GameObject[] totalEnemies;

  private bool canSpawn = false;
  private bool startSpawn = false;

  //Per eventualmente creare intermezzi tra waves
  private bool canAnimateWave = false;
  private float nextSpawnTime;


  private int currentWaveNum = 0;

  private Wave currentWave;



  void OnEnable(){
      EventManager.onStartGame += StartSpawningWave;
      EventManager.onStopWave += SpawnNextWave;
      //EventManager.onEnemyDeath += EnemyIsDead;
  }

  void OnDisable(){
      //StopSpawning();
      EventManager.onStartGame -= StartSpawningWave;
      EventManager.onStopWave -= SpawnNextWave;
      //EventManager.onEnemyDeath -= EnemyIsDead;
  }


  void Update(){
    currentWave = waves[currentWaveNum];

    SpawnWave();

    //guardo se tutti nemici sono morti
    GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");

    if(totalEnemies.Length == 0 && startSpawn){
      if(currentWaveNum + 1 != waves.Length){
          if(canAnimateWave){

            EventManager.StartWave();
            //waveName.text = waves[currentWaveNum + 1 ].waveName;
            canAnimateWave = false;

          }

          //qua si può aggiungere animazione

      }else{
        //gioco finito!
        SceneManager.LoadScene("GameOver");

      }
    }
  }

  void SpawnWave(){
    if(canSpawn && nextSpawnTime < Time.time){

      GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];

      Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

      Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity, transform);

      currentWave.numEnemies--;
      nextSpawnTime = Time.time + currentWave.spawnInterval;

      if(currentWave.numEnemies == 0){
        canSpawn = false;
        canAnimateWave = true;
      }

    }
  }

 void StartSpawningWave(){
   canSpawn = true;
   startSpawn = true;

 }


  public void SpawnNextWave(){
    currentWaveNum++;
    canSpawn = true;
  }
}
