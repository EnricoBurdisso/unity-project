using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float rotationalDamp = 0.5f;
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float rayCastOffset = 2.5f;
    [SerializeField] private float detectionDistance = 20f;

    void Update()
    {
        
        PathFinding();
        HaveLineOfSightRayCast();
        Move();
        Turn();
        
    }

    bool HaveLineOfSightRayCast()
    {
        RaycastHit hit;

        Vector3 direction = player.position - transform.position;

        //Debug.DrawRay(laser.transform.position, direction, Color.red);
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            if (hit.transform != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    Debug.DrawRay(transform.position, direction, Color.green);
                    //hitPosition = hit.transform.position;
                    return true;
                }
            }
        }
        Debug.DrawRay(transform.position, direction, Color.red);
        return false;
    }

    void Move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    void PathFinding()
    {
        RaycastHit hit;
        Vector3 raycastOffset = Vector3.zero;

        Vector3 left = transform.position - transform.right * rayCastOffset;
        Vector3 right = transform.position + transform.right * rayCastOffset;
        Vector3 up = transform.position + transform.up * rayCastOffset;
        Vector3 down = transform.position - transform.up * rayCastOffset;

        Debug.DrawRay(left, transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(right, transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(up, transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(down, transform.forward * detectionDistance, Color.cyan);

        if(Physics.Raycast(left,transform.forward,out hit, detectionDistance))
        {
            raycastOffset += Vector3.right;
        }else if(Physics.Raycast(right, transform.forward, out hit, detectionDistance)){
            raycastOffset -= Vector3.right;
        }
        if (Physics.Raycast(up, transform.forward, out hit, detectionDistance))
        {
            raycastOffset -= Vector3.up;
        }
        else if (Physics.Raycast(down, transform.forward, out hit, detectionDistance)){
            raycastOffset += Vector3.up;
        }
        if (raycastOffset != Vector3.zero)
        {
            transform.Rotate(raycastOffset * 5f * Time.deltaTime);
        }
        else
        {
            Turn();
        }
    }

    /*void FindMainCamera()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }*/

    /*void OnEnable()
    {
        EventManager.onPlayerDeath += FindMainCamera;
        EventManager.onStartGame += SelfDestruct;
    }

    void OnDisable()
    {
        EventManager.onPlayerDeath -= FindMainCamera;
        EventManager.onStartGame -= SelfDestruct;
    }*/


    void Turn()
    {
        Vector3 pos = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    
}
