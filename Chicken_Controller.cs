using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chicken_Controller : MonoBehaviour
{

    [SerializeField]
    float minX, maxX, minY, maxY;
    [SerializeField]
    Snake_Controller snake;



    // Start is called before the first frame update
    void Start()
    {
        RandomChickenPosition();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake"))
        {
            RandomChickenPosition();
            snake.CreateSegment();
            snake.SesCal();
        }
    }



    private void RandomChickenPosition()
    {

        transform.position = new Vector2(Mathf.Round(Random.Range(minX, maxX)) + 0.5f, Mathf.Round(Random.Range(minY, maxY)) + 0.5f);


    }

}
