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

                //Rotates the players z.rot to allign with the ship
                Quaternion initialRot = Quaternion.Euler(new Vector3(0, 0, other.transform.eulerAngles.z));
                other.transform.Rotate(0, 0, -initialRot.eulerAngles.z, Space.Self);
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
