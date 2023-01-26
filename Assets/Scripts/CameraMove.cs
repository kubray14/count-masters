using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform target;
    float distance;
    void Start()
    {
        distance = transform.position.z - target.position.z;
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + distance);
    }
}
