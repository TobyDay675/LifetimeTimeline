using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode left, right, jump;
    public float buildUp;
    public float maxSpeed;
    public float jumpForce;
    private bool isGrounded;

    public Rigidbody2D rb2D;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Move left and right
        if (Input.GetKey(left))
        {
            rb2D.AddForce(Vector2.left * buildUp * Time.deltaTime);
            sr.flipX = true;
            //GetComponent<Animator>().SetInteger("PlayerInput", 1);
        }
        if (Input.GetKeyUp(left))
        {
            rb2D.AddForce(Vector2.left * buildUp * Time.deltaTime);
            sr.flipX = true;
            //GetComponent<Animator>().SetInteger("PlayerInput", 0);
        }
        if (Input.GetKey(right))
        {
            rb2D.AddForce(Vector2.right * buildUp * Time.deltaTime);
            sr.flipX = false;
            //GetComponent<Animator>().SetInteger("PlayerInput", 1);
        }
        if (Input.GetKeyUp(right))
        {
            rb2D.AddForce(Vector2.right * buildUp * Time.deltaTime);
            sr.flipX = false;
            //GetComponent<Animator>().SetInteger("PlayerInput", 0);
        }

        if (Input.GetKey(jump) && isGrounded == true)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
        if (isGrounded == false)
        {
            //GetComponent<Animator>().SetInteger("PlayerInput", 3);
        }


        // Clamp the velocity
        rb2D.velocity = new Vector2(Mathf.Clamp(rb2D.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rb2D.velocity.y, -jumpForce, jumpForce));
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            //GetComponent<Animator>().SetInteger("PlayerInput", 0);
        }
    }
}
