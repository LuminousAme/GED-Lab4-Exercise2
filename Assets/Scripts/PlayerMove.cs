using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    //jump code based on https://youtu.be/c3iEl5AwUF8 
    Rigidbody2D rb;
    BoxCollider2D bc;
    [SerializeField] private LayerMask jumpableLayers;
    [SerializeField] private float jumpForce = 80f;
    [SerializeField] private float horimoveSpeed = 50f;
    public static event Action damageTaken;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bc = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0.0f && IsOnGround())
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    //FixedUpdate is called once per physics step
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * horimoveSpeed, rb.velocity.y);
    }

    //check if they're on screen
    private bool IsOnGround()
    {
        RaycastHit2D hit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, jumpableLayers);
        return hit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name == "enemy")
        {
            Health.instance.SetHealth(Health.instance.GetHealth() - 1);
            damageTaken?.Invoke();
        }
    }
}
