using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoController : MonoBehaviour{
    public int speed = 5;

    // Start is called before the first frame update
    //private Rigidbody2D rb;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    public string nextLevel = "Level2";
 
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update() {
        float xInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(xInput * speed, rb2d.velocity.y);
        //if (Input.GetKeyDown(KeyCode.Alpha1)) { 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {

            case "Death":
                {
                    string thisLevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thisLevel);
                    break;
                }
            case "Finish":
                { 
                    SceneManager.LoadScene(nextLevel);
                    break;
                } 
        }
      
 //Debug.Log("Hit");
    }
    // if (Input.GetKeyDown(KeyCode.A))
    //{
    //  rb.velocity = new Vector2(-1, rb.velocity.y);
    // }
    // if (Input.GetKeyDown(KeyCode.D))
    // {
    //     rb.velocity = new Vector2(1, rb.velocity.y);
    // }
    //rb.velocity = new Vector2(1, rb.velocity.y);
    /*
   if (Input.GetKeyDown(KeyCode.W))
   {
        transform.position += new Vector3(0, 1, 0);

    }
    if (Input.GetKeyDown(KeyCode.S))
    {
        transform.position += new Vector3(0, -1, 0);
    }
    if (Input.GetKeyDown(KeyCode.D))
    {
        transform.position += new Vector3(1, 0, 0);
    }
    if (Input.GetKeyDown(KeyCode.A))
    {
        transform.position += new Vector3(-1, 0, 0);
    }
    */


}

