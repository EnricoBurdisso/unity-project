using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    float minScale = .8f;
    float maxScale = 1.2f;

    float rotationOff = 40f;

    Transform asteroidT;
    Vector3 rotation;

    //Awake is called when the script instance is being loaded
    void Awake()
    {
      asteroidT = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
      //random scale
      Vector3 scale = Vector3.one;
      scale.x = Random.Range(minScale, maxScale);
      scale.y = Random.Range(minScale, maxScale);
      scale.z = Random.Range(minScale, maxScale);

      asteroidT.localScale = scale;            //scale serve per poter modificare localScale


      //random rotation

      rotation.x = Random.Range(-rotationOff, rotationOff);
      rotation.y = Random.Range(-rotationOff, rotationOff);
      rotation.z = Random.Range(-rotationOff, rotationOff);



    }

    // Update is called once per frame
    void Update()
    {
      asteroidT.Rotate(rotation * Time.deltaTime); //si usa deltaTime per permettere una rotazione morbida
    }
}
