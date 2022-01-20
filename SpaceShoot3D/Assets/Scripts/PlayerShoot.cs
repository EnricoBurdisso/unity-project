using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Laser laser;
    Transform mTransform;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        //mTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) //left click
        {
            //Vector3 pos = transform.position + (transform.forward * laser.Distance);
            //Vector3 pos = transform.forward * laser.Distance;

            //laser.FireLaser(pos);
            laser.FireLaser();
              //shoot


        }
    }
}
