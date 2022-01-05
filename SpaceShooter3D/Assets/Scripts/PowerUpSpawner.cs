using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    private List<GameObject> prefabListPowerup = new List<GameObject>();

    void Awake()
    {
        Object[] powerup = Resources.LoadAll("PowerUp", typeof(GameObject));       //inserisci tutti i prefab da scegliere
        if (powerup != null || powerup.Length > 0)
        {
            foreach (Object p in powerup)
            {
                GameObject a = (GameObject)p;
                prefabListPowerup.Add(a);
            }
        }
    }

    public List<GameObject> GetPrefabListPowerUp()
    {
        return prefabListPowerup;
    }

    public void InstantiatePowerUp()
    {
        int prefabIndex = UnityEngine.Random.Range(0, prefabListPowerup.Count);


        Instantiate(prefabListPowerup[prefabIndex],
                              new Vector3(transform.position.x , transform.position.y , transform.position.z),
                              Quaternion.identity);
        /*Instantiate(prefabListPowerup[prefabIndex],
                              new Vector3(transform.position.x , transform.position.y , transform.position.z),
                              Quaternion.identity);*/

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
