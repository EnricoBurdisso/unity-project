using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    float rotationOff = 40f,
                           minScale = .8f,
                           maxScale = 1.2f;

    Transform astroT;
    Vector3 rotation;


    void Awake()
    {
      astroT = transform;
    }


    void Start()
    {

      //random scale
      Vector3 scale = Vector3.one;
      scale.x = Random.Range(minScale, maxScale);
      scale.y = Random.Range(minScale, maxScale);
      scale.z = Random.Range(minScale, maxScale);

      astroT.localScale = scale;            //scale serve per poter modificare localScale


      //random rotation

      rotation.x = Random.Range(-rotationOff, rotationOff);
      rotation.y = Random.Range(-rotationOff, rotationOff);
      rotation.z = Random.Range(-rotationOff, rotationOff);
        //GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

    // Update is called once per frame
    void Update()
    {
      astroT.Rotate(rotation * Time.deltaTime); //si usa deltaTime per permettere una rotazione morbida
    }
}
