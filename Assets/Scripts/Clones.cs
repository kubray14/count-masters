using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clones : MonoBehaviour
{
    private Creator playerCreator;
    private Transform Center;
    [SerializeField] private float speed = 3f;

    private void Awake()
    {
        playerCreator = GameObject.FindGameObjectWithTag("base").GetComponent<Creator>();
        Center = GameObject.FindGameObjectWithTag("base").transform;
    }

    void FixedUpdate()
    {
            transform.position = Vector3.MoveTowards(transform.position, Center.position, Time.fixedDeltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            playerCreator.totalSize -=1;
            Destroy(this.gameObject,0.01f);
            playerCreator.players.Remove(this.gameObject);

        }
    }
}
