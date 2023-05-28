using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorandObs : MonoBehaviour
{
    public float speed;
    BoxCollider2D box;
    float floorWidth;
    float obstacleWidth;

    void Start()
    {
        if (gameObject.CompareTag("Floor"))
        {
            box = GetComponent<BoxCollider2D>();
            floorWidth = box.size.x;
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            obstacleWidth=GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }
        
    }

    
    void Update()
    {
        if (GameManager.gameOver == false)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y); //x yönünde hareket etsin ama y yönünde sabit kalsýn dedik.
        }
       

        if (gameObject.CompareTag("Floor"))
        {

            if (transform.position.x <= -floorWidth)
            {
                transform.position = new Vector2(transform.position.x + 2 * floorWidth, transform.position.y);
            }
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            if(transform.position.x<GameManager.bottomLeft.x-obstacleWidth)
            {
                Destroy(gameObject);
            }
        }

    }
}
