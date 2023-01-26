using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
     float speed = 7f;
    float timeRemain = 5;

    void Update()
    {
        if (timeRemain >0) // her 5 saniyede h�zlar�n�n de�i�mesi i�in gerekli olan timer d�ng�s�.
        {
            timeRemain -= Time.deltaTime;
        }
        else
        {
            speed = (Random.value + 0.1f) * 10;
            timeRemain = 5;
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x >= 4.1f)
        {
            speed *= 1;
        }
        if (transform.position.x <= -4.1f)
        {
            speed *= -1;
        }


    }
}
