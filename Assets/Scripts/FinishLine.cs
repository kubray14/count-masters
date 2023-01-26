using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    private GameManager gm;
    private Player player;
    private Creator creator;
    [SerializeField] Text score;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("base").GetComponent<Player>();
        creator = GameObject.FindGameObjectWithTag("base").GetComponent<Creator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            score.text = "Your score: " + creator.totalSize.ToString();
            gm.finishPanel.SetActive(true);
            player.isStart = false;
        }
    }
}
