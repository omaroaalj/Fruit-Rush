using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    private int jumpCount = 0;
    public int jumpCountMax = 2;
    public float jumpForce = 7f;
    public float moveSpeed = 7f;
    private bool moveRight = false;
    private bool moveLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check for jump touch
            if (touch.phase == TouchPhase.Began && jumpCount < jumpCountMax)
            {
                player.velocity = new Vector2(player.velocity.x, jumpForce);
                jumpCount++;
            }

            // Check for move touch
            if (touch.phase == TouchPhase.Moved)
            {
                // Get touch delta position and move player accordingly
                float touchDelta = touch.deltaPosition.x / Screen.width;
                player.velocity = new Vector2(touchDelta * moveSpeed, player.velocity.y);

                // Flip player sprite if moving left
                if (touchDelta < 0f)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                }
                else if (touchDelta > 0f)
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                }
            }
        }

        // Check for keyboard input
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < jumpCountMax)
        {
            player.velocity = new Vector2(player.velocity.x, jumpForce);
            jumpCount++;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.velocity = new Vector2(moveSpeed, player.velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f); // Set scale to normal
            moveRight = true;
            moveLeft = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.velocity = new Vector2(-moveSpeed, player.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f); // Flip scale
            moveRight = false;
            moveLeft = true;
        }
        else
        {
            player.velocity = new Vector2(0f, player.velocity.y);
            moveRight = false;
            moveLeft = false;
        }

        // Check if player is stuck when colliding with an object
        if (Mathf.Abs(player.velocity.x) < 0.01f)
        {
            player.velocity = new Vector2(0.01f * Mathf.Sign(player.velocity.x), player.velocity.y);
        }
    }

    private void FixedUpdate()
    {
        if (moveRight)
        {
            player.velocity = new Vector2(moveSpeed, player.velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f); // Set scale to normal
        }
        else if (moveLeft)
        {
            player.velocity = new Vector2(-moveSpeed, player.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f); // Flip scale
        }
    }

 private void OnCollisionEnter2D(Collision2D collision)
{
    jumpCount = 0;

    // Check if player collided with a platform
    foreach (ContactPoint2D contact in collision.contacts)
    {
        if (contact.normal.y > 0.5f)
        {
            return;
        }
    }

    // Flip player sprite if moving left
    if (moveLeft)
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    // Flip player sprite if moving right
    else if (moveRight)
    {
        transform.localScale = new Vector3(-1f, 1f, 1f);
    }
}
}
