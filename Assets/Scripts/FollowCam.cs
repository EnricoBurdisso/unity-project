using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
  [SerializeField] Transform target;
  [SerializeField] Vector3 defDistance = new Vector3(0f, 2f, -10f);
  [SerializeField] float distanceDamp  = 10f;
  [SerializeField] float rotationDamp  = 2f;

  Transform shipT;

  void Awake(){
    shipT = transform;
  }

  //viene eseguito dopo l'update di player
  void LateUpdate(){

    //seguie la posizione del target
    Vector3 toPosition = target.position + (target.rotation * defDistance);
    Vector3 curPosition = Vector3.Lerp(shipT.position, toPosition, distanceDamp * Time.deltaTime);
    shipT.position = curPosition;

    //segue la rotazione dl target
    Quaternion toRotation = Quaternion.LookRotation(target.position - shipT.position, target.up);
    Quaternion curRotation = Quaternion.Slerp(shipT.rotation, toRotation, rotationDamp * Time.deltaTime);
    shipT.rotation = curRotation;

  }





}
