using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 100f;
    [SerializeField] private float turnSpeed = 50f;
    Transform mTransform;
    // Start is called before the first frame update

    private void Awake()
    {
        mTransform = GetComponent<Transform>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        Speed();
    }
    void Speed()
    {
        mTransform.position += mTransform.forward * movementSpeed * Time.deltaTime * Input.GetAxis("ForwardBackward");
    }
    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Yaw"); //Yaw
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch"); //Pitch
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll"); //Roll

        mTransform.Rotate(pitch, yaw, roll);
    }
}
