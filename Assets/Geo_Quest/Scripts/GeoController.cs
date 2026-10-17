using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoController : MonoBehaviour{
    public int speed = 6;
    public float jumpForce = 6f;

    // Start is called before the first frame update
    //private Rigidbody2D rb;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    public string nextLevel = "Level2";

    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;
    public float groundCheckRadius = 0.2f;
    [Header("Player Sprites")]
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public int score = 0;
    
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       

    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(xInput * speed, rb2d.velocity.y);
        //if (Input.GetKeyDown(KeyCode.Alpha1)) { 
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }
        else
        {
            isGrounded = Mathf.Abs(rb2d.velocity.y) < 0.01f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && sprite1 != null)
        {
            spriteRenderer.sprite = sprite1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && sprite2 != null)
        {
            spriteRenderer.sprite = sprite2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && sprite3 != null)
        {
            spriteRenderer.sprite = sprite3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && sprite4 != null)
        {
            spriteRenderer.sprite = sprite4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && sprite5 != null)
        {
            spriteRenderer.sprite = sprite5;
        }
        
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
            case "Coin":
                {
                    score++;
                    Debug.Log("Coins Collected: " + score);
                    Destroy(collision.gameObject);
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

