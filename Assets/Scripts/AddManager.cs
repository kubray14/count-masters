using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddManager : MonoBehaviour
{
    int[] values = { 20, 15, 25, 30, -50};  // gate numbers by index
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
            if (values[index] < 0)
            {
                int value = values[index] * (-1);
                playerCreator.totalSize -= value;
                for (int i = 0; i < value; i++)
                {
                    playerCreator.players.Remove(other.gameObject);
                    Destroy(playerCreator.players[i].gameObject);
                }
                index++;
                MultiplyManager.index++;
            }
            else
            {
                float spawn = playerCreator.totalSize;
                playerCreator.totalSize += values[index];
                spawn = playerCreator.totalSize - spawn;
                playerCreator.SpawnClones(spawn);
                index++;
                MultiplyManager.index++;
            }
        }
    }
}
