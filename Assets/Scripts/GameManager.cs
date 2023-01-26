using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Player player;
    [SerializeField] public GameObject startPanel;
    [SerializeField] public GameObject restartPanel;
    [SerializeField] public GameObject finishPanel;
    public bool isRestart = false;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("base").GetComponent<Player>();
    }
    public void startGame()
    {
        player.isStart = true;
        startPanel.SetActive(false);
    }
    public void exitGame() {

        Application.Quit();
    }
    public void restartGame()
    {
        restartPanel.SetActive(false);
        finishPanel.SetActive(false);
        isRestart = true;
        MultiplyManager.index = 0;
        AddManager.index = 0;
        SceneManager.LoadScene(0);


    }
}
