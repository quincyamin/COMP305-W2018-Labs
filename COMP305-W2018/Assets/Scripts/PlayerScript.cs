using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public KeyCode moveRightKey;
    public KeyCode moveLeftKey;
    public KeyCode jumpKey;
    public LayerMask ground;

    public float speed = 2f;
    public float jumpForce = 2f;

    private bool canJump;
    private bool jumpCompleted;

    private Animator animator;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _renderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        canJump = false;
        jumpCompleted = false;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(moveRightKey))
        {
            animator.SetFloat("run", speed);
            _rigidbody2D.AddForce(Vector2.right * speed);
            _renderer.flipX = false;
        }
        else if (Input.GetKey(moveLeftKey))
        {
            animator.SetFloat("run", speed);
            _rigidbody2D.AddForce(Vector2.left * speed);
            _renderer.flipX = true;
        }
        else
        {
            animator.SetFloat("run", 0);
            _rigidbody2D.AddForce(Vector2.zero);
        }

        if (IsGrounded()) canJump = true;
        else canJump = false;


        if (Input.GetKey(jumpKey) && canJump)
        {
            animator.SetFloat("jump", jumpForce);
            _rigidbody2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            jumpCompleted = false;
        }

        if (canJump && jumpCompleted)
            animator.SetFloat("jump", 0);
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1f, ground);

        if (hit)
        {
            if (hit.collider.gameObject.tag == "Ground")
                jumpCompleted = true;
            return true;
        }
        return false;
    }
}