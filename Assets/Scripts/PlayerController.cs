using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float velocity;
    private bool isJumping = false;

    private Animator playerAnim;
    private Health health;

    private Rigidbody2D playerRb;

    public bool isActive = false;
    public bool isLoser = false;
    // Start is called before the first frame update
    void Awake()
    {
        playerAnim = GetComponent<Animator>();
        playerAnim.SetBool("isJumping", false);
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && !isLoser)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            ChangeAnim(horizontalInput);
        
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                Move(horizontalInput);
                playerAnim.SetBool("isMoving", true);
            }
            else
            {
                playerAnim.SetBool("isMoving", false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
            {
                Jump();
            }
        }

        if (isLoser)
        {
            playerAnim.SetTrigger("isDead");
        }
    }

    void ChangeAnim(float horizontalInput)
    {
        if (horizontalInput > 0.1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalInput < -0.1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void Move(float horizontalInput)
    {
        if (horizontalInput > 0.1)
        {
            transform.Translate(speed * Time.deltaTime * horizontalInput, 0, 0);
        }
        else if (horizontalInput < -0.1)
        {
            transform.Translate(speed * Time.deltaTime * -horizontalInput, 0, 0);    
        }
    }

    void Jump()
    {
        isJumping = true;
        playerAnim.SetBool("isJumping", true);
        playerRb.AddForce(Vector2.up * velocity, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            playerAnim.SetBool("isJumping", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        health = GameObject.Find("Slider").GetComponent<Health>();
        if (other.gameObject.CompareTag("Enemy"))
        {
            health.AlterHealth(1);
            Destroy(other.gameObject);
        }
    }

    private void Disappear()
    {
        gameObject.SetActive(false);
    }
}
