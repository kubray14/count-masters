using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyManager : MonoBehaviour
{
    float[] values = { 10, 2, 3, 2, 0.5f}; // gate numbers by index
    public static int index = 0;
    private Creator playerCreator;


    private void Awake()
    {
        playerCreator = GameObject.FindGameObjectWithTag("base").GetComponent<Creator>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (values[index] < 1)
            {
                int value = (int)playerCreator.totalSize;
                playerCreator.totalSize = (int)(values[index] * playerCreator.totalSize);
                value = value - (int)playerCreator.totalSize;
                for (int i = 0; i < value; i++)
                {
                    playerCreator.players.Remove(other.gameObject);
                    Destroy(playerCreator.players[i].gameObject);
                }
                index++;
                AddManager.index++;
            }
            else 
            {
                float spawn = playerCreator.totalSize;
                playerCreator.totalSize *= values[index];
                spawn = playerCreator.totalSize - spawn;
                playerCreator.SpawnClones(spawn);
                index++;
                AddManager.index++;
            }
        }
    }
}
