using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    //[SerializeField] float spawnTime = 5f;
    [SerializeField] int grid = 50,
                        numEnemy = 5;

    void Start(){
        GenerateEnemies();
    }



    void GenerateEnemies()
    {
      for(int x = 0; x < numEnemy; x++){
        for(int y = 0; y < numEnemy; y++){
          for(int z = 0; z < numEnemy; z++){
            InstantiateEnemy(x, y, z);
          }
        }
      }
    }

    void InstantiateEnemy(int x, int y, int z){

      Instantiate(enemyPrefab,
                            new Vector3(transform.position.x + (x * grid) + EnemyOff(),
                                        transform.position.y + (y * grid) + EnemyOff(),
                                        transform.position.z + (z * grid) + EnemyOff()),
                                        Quaternion.identity, transform);

    }

    float EnemyOff(){
      return Random.Range(-grid/2f, grid/2f);
    }
    /*

    void Start(){
      StartSpawning();
    }

    void SpawnEnemy(){
      Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    void StartSpawning(){
       InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
    }

    void StopSpawning(){
      CancelInvoke();
    }
    */


}
