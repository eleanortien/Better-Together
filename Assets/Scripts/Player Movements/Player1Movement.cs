using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player1State
{
    walk,
    interact
}
public class Player1Movement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 5f;
    public int groundLayer = 3;
    public Rigidbody2D rb;
    public Player1State currentState;
    private float minX, maxX, minY, maxY;

    private bool isGrounded = false;

    Animator animator;
   
    void Start()
    {
        //Find Screen Boundaries
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(-1, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(2, 1, camDistance));
        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;

        currentState = Player1State.walk;
        animator = GetComponent<Animator>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer && !isGrounded )
        {
            isGrounded = true;
        }
    }


    void Update()
    {
        if (currentState == Player1State.interact)
        {
            rb.velocity = Vector2.zero;
            { }
            return;
        }

        //Key Inputs
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * moveSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector2.right * moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        //Screen Boundaries
        Vector2 pos = transform.position;
        // Horizontal contraint
        if (pos.x < minX) pos.x = minX;
        if (pos.x > maxX) pos.x = maxX;
        // vertical contraint
        if (pos.y < minY)
        {
            GameManager.instance.GameOver();
        }
        if (pos.y > maxY) pos.y = maxY;
        // Update position
        transform.position = pos;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (Input.GetKey(KeyCode.Return) && collision.gameObject.CompareTag("Switch"))
        {
            collision.gameObject.GetComponent<SwitchTerminal>().TriggerSwitch();
        }


        else if (Input.GetKey(KeyCode.Return) && collision.gameObject.CompareTag("Terminal"))
        {
            collision.gameObject.GetComponent<Terminal>().TriggerTerminal();
        }


    }
}
  
       


  

