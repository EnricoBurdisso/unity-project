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
        mTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) //left click
        {
            laser.FireLaser();
            //shoot
           

        }
    }
}
