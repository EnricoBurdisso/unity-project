using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private List<GameObject> prefabPowerUp=new List<GameObject>();

    void Awake()
    {
        Object[] powerup = Resources.LoadAll("PowerUp", typeof(GameObject));       //inserisci tutti i prefab da scegliere
        if (powerup != null || powerup.Length > 0)
        {
            foreach (Object p in powerup)
            {
                GameObject a = (GameObject)p;
                prefabPowerUp.Add(a);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InstantiatePowerUp()
    {
        int prefabIndex = UnityEngine.Random.Range(0, prefabPowerUp.Count);
        Instantiate(prefabPowerUp[prefabIndex], new Vector3(transform.position.x, transform.position.y, transform.position.z),
            Quaternion.identity);
    }
}
