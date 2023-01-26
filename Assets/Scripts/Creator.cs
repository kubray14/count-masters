using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Creator : MonoBehaviour
{
    public GameObject player;
    public TextMeshPro CountText;
    public List<GameObject> players = new List<GameObject>();
    public float totalSize=1;

    void Update()
    {
        if( totalSize >= 0)
        {
            CountText.text = totalSize.ToString();
        }
        else
        {
            CountText.text = "0";
        }
    }

    public void SpawnClones(float size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject newPlayer = Instantiate(player, PlayerPosition(), Quaternion.identity, transform);
            players.Add(newPlayer);
        }
    }

    public Vector3 PlayerPosition()
    {
        
        Vector3 pos = Random.insideUnitSphere * 1f;
        Vector3 newPos = transform.position + pos;
        newPos.y = 0.65f;
        return newPos;
    }

}
