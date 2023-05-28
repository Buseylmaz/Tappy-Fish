using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D rg;
    int angle;
    int maxAngle = 20;
    int minAngle = -60;
    public Score score;
    bool touchedFloor;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;
    public ObstacleSpawner obstacleSpawner;

    [SerializeField]
    AudioSource fishSwim;

    [SerializeField]
    float speed;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        rg.gravityScale = 0;
        sp= GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }


    void Update()
    {
        FishSwim();
        
    }

    void FixedUpdate()
    {
        FishRotation();
    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver==false)
        {
            fishSwim.Play();

            if (GameManager.gameStared == false)
            {
                rg.gravityScale = 1.8f;
                rg.velocity=Vector2.zero;
                rg.velocity=new Vector2(rg.velocity.x,speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            else
            {
                rg.velocity = Vector2.zero;
                rg.velocity = new Vector2(rg.velocity.x, speed);
            }
            
        }

    }

    void FishRotation()
    {
        if (rg.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle += 4;
            }
        }
        else if (rg.velocity.y < -2) //hýzlý bir þekilde aþagýya dönmesin diye -1.2 deðerini ekeldik.
        {
            if (angle > minAngle)
            {
                angle -= 2;
            }
            
        }
        if (touchedFloor == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle); //açýsal dönüþü verebilmek için kullanýyoruz.
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            score.Scored();
        }
        else if (collision.CompareTag("Column") && GameManager.gameOver==false)
        {
            gameManager.GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            if(GameManager.gameOver==false)
            {
                gameManager.GameOver();
                GameOver();//fish içinde ki gameover
            }
            else
            {
                GameOver();//fish içindeki gameover
            }
        }
    }

    void GameOver()
    {
        touchedFloor = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = fishDied;
        anim.enabled= false;
    }
}
