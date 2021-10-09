using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public GameObject rotatePoint;
    public ParticleSystem particle;

    float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            rotatePoint.transform.Rotate(0, 0, rotationSpeed);
            particle.Emit(1);
        }
    }
}
