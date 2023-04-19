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

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < jumpCountMax)
        {
            player.velocity = new Vector2(player.velocity.x, jumpForce);
            jumpCount++;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.velocity = new Vector2(moveSpeed, player.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.velocity = new Vector2(-moveSpeed, player.velocity.y);
        }

        // Check if player is stuck when colliding with an object
        if (Mathf.Abs(player.velocity.x) < 0.01f)
        {
            player.velocity = new Vector2(0.01f * Mathf.Sign(player.velocity.x), player.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        jumpCount = 0;

        transform.up = Vector3.up;
    }
}