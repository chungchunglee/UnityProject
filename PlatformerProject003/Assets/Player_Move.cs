using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    private float jumpForce = 8.0f;
    private Rigidbody2D rigid2D;
    private CapsuleCollider2D capsuleCollider2D;
    private LayerMask groundLayer;
    private bool isGrounded;
    private Vector3 footPosition;
    SpriteRenderer spriteRenderer;


    [HideInInspector]
    public bool isLongJump = false;


    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    public void Move(float x)
    {

        rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
        if (x == 1)
        {
            spriteRenderer.flipX = false;
        }
        else if (x == -1)
        {
            spriteRenderer.flipX = true;
        }
    }
    
    private void FixedUpdate()
    {

        Bounds bounds = capsuleCollider2D.bounds;
        footPosition = new Vector2(bounds.center.x, bounds.min.y);
        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);
        if(isLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = 1.0f;
        }
        else
        {
            rigid2D.gravityScale = 2.5f;
        }
    }
    public void Jump()
    {
        //if(isGrounded==true)
        {
            rigid2D.velocity = Vector2.up * jumpForce;
        }
    }

}
