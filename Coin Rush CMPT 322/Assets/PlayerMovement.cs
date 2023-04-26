using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    private bool isJumping = false;
    private int jumpCount = 0;
    public int jumpCountMax = 2;
    public float jumpForce = 7f;
    public float moveSpeed = 3f;

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

            // Check touch phase
            if (touch.phase == TouchPhase.Began && jumpCount < jumpCountMax)
            {
                // Record touch position on touch began
                if (touch.position.x > Screen.width / 2)
                {
                    player.velocity = new Vector2(moveSpeed, player.velocity.y);
                    transform.localScale = new Vector3(1f, 1f, 1f); // Flip right
                }
                else if (touch.position.x < Screen.width / 2)
                {
                    player.velocity = new Vector2(-moveSpeed, player.velocity.y);
                    transform.localScale = new Vector3(-1f, 1f, 1f); // Flip left
                }
            }

            // Check if touch is released and perform jump
            if (touch.phase == TouchPhase.Ended)
            {
                isJumping = true;
            }
        }

        // Check for keyboard input
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < jumpCountMax)
        {
            isJumping = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.velocity = new Vector2(moveSpeed, player.velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f); // Flip right
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.velocity = new Vector2(-moveSpeed, player.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f); // Flip left
        }

        // Check if player is stuck when colliding with an object
        if (Mathf.Abs(player.velocity.x) < 0.01f)
        {
            player.velocity = new Vector2(0.01f * Mathf.Sign(player.velocity.x), player.velocity.y);
        }

        // Perform jump when isJumping is true and reset isJumping
        if (isJumping)
        {
            player.velocity = new Vector2(player.velocity.x, jumpForce);
            jumpCount++;
            isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCount = 0;
        transform.up = Vector3.up;
    }
}
