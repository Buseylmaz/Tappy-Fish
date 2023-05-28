using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    Text scoreText;

    int highScore;
    public Text panelScore;
    public Text panelHighScore;

    public GameObject newPanel;
    
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text=score.ToString();
        panelScore.text=score.ToString();
        highScore = PlayerPrefs.GetInt("highscore");
        panelHighScore.text=highScore.ToString();
    }

    public void Scored()
    {
        score += 1;
        scoreText.text=score.ToString();
        panelScore.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            panelHighScore.text = highScore.ToString();
            PlayerPrefs.SetInt("highscore", highScore);
            newPanel.SetActive(true);
        }
    }

    public int GetScore()
    {
        return score;
    }
}
