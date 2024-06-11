using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator playerAnim;
    private Rigidbody2D rbPlayer;
    public float speed;
    private SpriteRenderer sr;
    private GameController gcPlayer;
    public float jumpForce;
    public bool inFloor = true;
    public bool doubleJump = false;

    void Start()
    {
        gcPlayer = GameController.gc;

        playerAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void MovePlayer()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        rbPlayer.velocity = new Vector2(horizontalMovement * speed, rbPlayer.velocity.y);

        if (horizontalMovement > 0)
        {
            playerAnim.SetBool("Walk", true);
            sr.flipX = false;
        }
        else if (horizontalMovement < 0)
        {
            playerAnim.SetBool("Walk", true);
            sr.flipX = true;
        }
        else
        {
            playerAnim.SetBool("Walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (inFloor)
            {
                rbPlayer.velocity = Vector2.zero;
                playerAnim.SetBool("Jump", true);
                rbPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                inFloor = false;
                doubleJump = true;
            }
            else if (doubleJump)
            {
                rbPlayer.velocity = Vector2.zero;
                playerAnim.SetBool("Jump", true);
                rbPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                doubleJump = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            playerAnim.SetBool("Jump", false);
            inFloor = true;
            doubleJump = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);
            gcPlayer.Coins++;
            gcPlayer.CoinsText.text = gcPlayer.Coins.ToString();
        }
    }

}

