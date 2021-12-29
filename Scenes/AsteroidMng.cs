using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMng : MonoBehaviour
{
    //[SerializeField]Asteroid asteroid;

    [SerializeField]Planet asteroid;

    int grid = 50;
    int numAsteroid = 5;

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

    void InstantiateAsteroids(int x, int y, int z){

      Instantiate(asteroid, new Vector3(transform.position.x + (x * grid) + AsteroidOff(),
                                        transform.position.y + (y * grid) + AsteroidOff(),
                                        transform.position.z + (z * grid) + AsteroidOff()),
                                        Quaternion.identity, transform);

    }


    float AsteroidOff(){
      return Random.Range(-grid/2f, grid/2f);
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
}
