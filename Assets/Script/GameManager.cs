using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameOver;

    public GameObject gameOverPanel;
    public GameObject readyPanel;

    public static bool gameStared;
    public static int gameScore;
    public GameObject score;

    void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }

    void Start()
    {
        gameOver = false;
        gameStared = false;
    }

    public void GameHasStarted()
    {
        gameStared = true;
        readyPanel.SetActive(false);
    }

    public void GameOver()
    {
        gameOver=true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
        gameScore = score.GetComponent<Score>().GetScore();
    }
    
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

   
}
