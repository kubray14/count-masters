using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammer : MonoBehaviour
{
    Vector3 currentEulerAngles;
   float rotationSpeed = 20;
    void Update()
    {
        currentEulerAngles += new Vector3(0, 0, 1f) * Time.deltaTime * rotationSpeed;

        if (transform.rotation.z >= 0.25f)
        {
            rotationSpeed = -20;
        }
        if (transform.rotation.z <= -0.18f)
        {
            rotationSpeed = 20;
        } 
        transform.eulerAngles = currentEulerAngles;
    }
} 
