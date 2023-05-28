using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    public Sprite metalMedal, bronzMedal, silverMedal, goldMedal;
    Image img;



    void Start()
    {
        
    }

    
    void Update()
    {
        img=GetComponent<Image>();
        int gameScore = GameManager.gameScore;

        if(gameScore > 0 && gameScore <= 15)
        {
            img.sprite = metalMedal;
        }
        else if (gameScore > 15 && gameScore <= 20)
        {
            img.sprite = bronzMedal;
        }
        else if (gameScore > 20 && gameScore <= 25)
        {
            img.sprite = silverMedal;
        }
        else 
        {
            img.sprite = goldMedal;
        }
    }
}
