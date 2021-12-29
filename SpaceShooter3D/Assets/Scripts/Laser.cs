using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    private LineRenderer lineRenderer;
    Transform mTransform;
    [SerializeField] private float laserOff = 0.5f;
    [SerializeField] private float maxDistanceShoot = 10f; // boh
    [SerializeField] private float fireDelay = 2f;
    private bool canFire;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.enabled = false;
        canFire = true;
    }
    private void Awake()
    {
        mTransform = GetComponent<Transform>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FireLaser()
    {
            RaycastHit hit;

            Vector3 fwd = mTransform.TransformDirection(Vector3.forward) * maxDistanceShoot;

            if (Physics.Raycast(mTransform.position, fwd, out hit))
            {
                Debug.Log("We hit: " + hit.transform.name + " with tag: " + hit.transform.tag);
            }
        // render line render -> laser
        /*lineRenderer.SetPosition(0, mTransform.position);
        lineRenderer.SetPosition(1, hit.point);*/
        if (canFire)
        {
            lineRenderer.enabled = true;
            canFire = false;
            Invoke("LaserOff", laserOff);
            Invoke("CanFire", fireDelay);
        }
    }
    void LaserOff()
    {
        lineRenderer.enabled = false;
    }
    void CanFire()
    {
        canFire = true;
    }
}
