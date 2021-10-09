using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShield : MonoBehaviour
{
    GameObject cam;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void OnTriggerEnter(Collider other)
    {
        if  (other.tag == "Player")
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            playerMovement.isInSpace = !playerMovement.isInSpace;


            //Change de parent of the player
            if (playerMovement.isInSpace == false)
            {
                other.transform.parent = GameObject.FindGameObjectWithTag("Ship").transform;
            }
            else
            {
                other.transform.SetParent(null);

                //Resets the camAngles
                //Should be a lerp
                //cam.transform.eulerAngles = new Vector3(0, 0, 0);
                Quaternion targetRot = Quaternion.identity;
                targetRot = Quaternion.Euler(0, 0, 0);
                cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, targetRot, 1f * Time.deltaTime);
            }
        }
    }
}
