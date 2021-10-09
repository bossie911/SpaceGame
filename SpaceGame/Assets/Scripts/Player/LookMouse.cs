using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMouse : MonoBehaviour
{
    private float mouseSensitivity = 300f;

    public Transform playerBody;

    public GameObject player;

    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Getting Mouse Axis
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        //Different Camera rotation when in space or not
        if (playerMovement.isInSpace == false)
        {
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            player.transform.Rotate(Vector3.up * mouseX);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            player.transform.Rotate(Vector3.up * mouseX);
            player.transform.Rotate(Vector3.right * -mouseY);
        }
    }
}
