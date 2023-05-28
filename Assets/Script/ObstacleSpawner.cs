using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //Engel olu�turmak i�in yaz�lan kod k�sm�

    public GameObject obstacle;
    public float maxTime;
    float timer;
    public float maxY;
    public float minY;
    float randomY;
    
    void Start()
    {
        //InstantiateObstacle();
    }

    
    void Update()
    {
        if (GameManager.gameOver == false && GameManager.gameStared==true)
        {
            //Belli aral�klarla engel �retmesi i�in zamanlay�c� kulland�k
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                randomY = Random.Range(minY, maxY);
                InstantiateObstacle();
                timer = 0;
            }
        }
        
    }

    public void InstantiateObstacle()//Olu�turma
    {
        GameObject newObstacle=Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x,randomY);
    }




}
