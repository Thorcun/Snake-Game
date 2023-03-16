using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake_Controller : MonoBehaviour
{

    private Vector2 direction;
    [SerializeField]
    private GameObject segmentprefab;
    private List<GameObject> segments = new List<GameObject>();
    

    bool isyukari=false;
    bool isasagi=false;
    bool issag=false;
    bool issol=false;

    AudioSource ses;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        ResetSegment();
        segments[1].tag = "IlkSegment";
        ses = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetUserInput();
    }

    private void FixedUpdate()
    {
        SnakeMove();
        MoveSegment();
    }

    private void Reset()
    {      
        direction = Vector2.right;
        Time.timeScale = 0.1f;
        issag = true;
    }

    public void CreateSegment()
    {
        GameObject newsegment = Instantiate(segmentprefab);
        newsegment.transform.position = segments[segments.Count - 1].transform.position;
        segments.Add(newsegment);
    }

    public void SesCal()
    {


        ses.Play();

    }
    private void ResetSegment()
    {

        for (int i = 1;  i < segments.Count; i++)
        {

            Destroy(segments[i]);


        }

        segments.Clear();
        segments.Add(gameObject);

        for (int i = 0; i < 3; i++)
        {
            CreateSegment();
        }

    }

    private void MoveSegment()
    {

        for (int i=segments.Count-1; i>0;  i--)
        {

            segments[i].transform.position = segments[i-1].transform.position;

        }

    }

    private void RestrartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void SnakeMove()
    {

        float x, y;
        x = transform.position.x + direction.x;
        y = transform.position.y + direction.y;

        transform.position = new Vector2 (x, y);
    }




    private void GetUserInput()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            
            if (!isasagi)
            {
                direction = Vector2.up;
                isyukari = true;
                issag = false;
                issol = false;
            }
        }
        else if (Input.GetKeyDown (KeyCode.S)) 
        {
            
            if (!isyukari)
            {
                direction = Vector2.down;
                isasagi=true;
                issag=false;
                issol=false;
            }
                   
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            
            if (!issol)
            {
                direction = Vector2.right;
                isyukari = false;
                isasagi = false;
                issag = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (!issag)
            {
                direction = Vector2.left;
                isyukari = false;
                isasagi = false;
                issol = true;

            }
            
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            RestrartGame();
        }

        if (collision.gameObject.CompareTag("Segment"))
        {

            RestrartGame();

        }
    }


}
