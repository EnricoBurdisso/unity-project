using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
  [SerializeField] Transform player;
  [SerializeField] Vector3 defDistance = new Vector3(0f, 2f, -10f);
  [SerializeField] float distanceDamp  = 10f;
  [SerializeField] float rotationDamp  = 2f;

  Transform shipT;

  void Awake(){
    shipT = transform;
  }

  //viene eseguito dopo l'update di player
  void LateUpdate(){

        if (!FindPlayer())
        {
            return;
        }

        //seguie la posizione del target
        Vector3 toPosition = player.position + (player.rotation * defDistance);
    Vector3 curPosition = Vector3.Lerp(shipT.position, toPosition, distanceDamp * Time.deltaTime);
    shipT.position = curPosition;

    //segue la rotazione dl target
    Quaternion toRotation = Quaternion.LookRotation(player.position - shipT.position, player.up);
    Quaternion curRotation = Quaternion.Slerp(shipT.rotation, toRotation, rotationDamp * Time.deltaTime);
    shipT.rotation = curRotation;

  }

    bool FindPlayer()
    {
        if (player == null)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("Player");
            if (temp != null)
            {
                player = temp.transform;
            }
        }

        if (player == null)
        {
            return false;
        }
        return true;
    }





}
