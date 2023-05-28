using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //Engel oluþturmak için yazýlan kod kýsmý

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
            //Belli aralýklarla engel üretmesi için zamanlayýcý kullandýk
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                randomY = Random.Range(minY, maxY);
                InstantiateObstacle();
                timer = 0;
            }
        }
        
    }

    public void InstantiateObstacle()//Oluþturma
    {
        GameObject newObstacle=Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x,randomY);
    }




}
