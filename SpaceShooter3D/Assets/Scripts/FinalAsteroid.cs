using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAsteroid : MonoBehaviour
{

    List<GameObject> prefabList = new List<GameObject>();

    [SerializeField] int grid = 50,
                         numAsteroid = 5;



    void Awake(){
      Object[] asteroids = Resources.LoadAll("Asteroids" , typeof(GameObject));       //inserisci tutti i prefab da scegliere
      if(asteroids != null || asteroids.Length > 0){
        foreach(Object astro in asteroids){
          GameObject a = (GameObject) astro;
          prefabList.Add(a);
        }
      }
    }

    // Start is called before the first frame update
    void Start()
    {

        GenerateAsteroids();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Crea una griglia di asteroidi
    void GenerateAsteroids()
    {
      for(int x = 0; x < numAsteroid; x++){
        for(int y = 0; y < numAsteroid; y++){
          for(int z = 0; z < numAsteroid; z++){
            InstantiateAsteroids(x, y, z);
          }
        }
      }
    }

    //Crea un cubo di asteroidi
    void GenerateAsteroids(int x)
    {

    }





    void InstantiateAsteroids(int x, int y, int z){

      int prefabIndex = UnityEngine.Random.Range(0, prefabList.Count);

      Instantiate(prefabList[prefabIndex],
                            new Vector3(transform.position.x + (x * grid) + AsteroidOff(),
                                        transform.position.y + (y * grid) + AsteroidOff(),
                                        transform.position.z + (z * grid) + AsteroidOff()),
                                        Quaternion.identity, transform);

    }


    float AsteroidOff(){
      return Random.Range(-grid/2f, grid/2f);
    }
}
