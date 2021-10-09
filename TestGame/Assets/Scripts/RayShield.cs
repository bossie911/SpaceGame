using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShield : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if  (other.tag == "Player")
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            playerMovement.isInSpace = !playerMovement.isInSpace;
            playerMovement.velocity.y = 0f;
        }
    }
}
