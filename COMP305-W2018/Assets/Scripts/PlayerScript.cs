using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public KeyCode moveRightKey;
    public KeyCode moveLeftKey;
    public KeyCode jumpKey;
    public LayerMask ground;

    public float Speed = 2f;
    public float JumpForce = 2f;

    private bool _canJump;
    private bool _jumpCompleted;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _canJump = false;
        _jumpCompleted = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(moveRightKey))
        {
            _animator.SetFloat("run", Speed);
            _rigidbody2D.AddForce(Vector2.right * Speed);
            _renderer.flipX = false;
        }
        else if (Input.GetKey(moveLeftKey))
        {
            _animator.SetFloat("run", Speed);
            _rigidbody2D.AddForce(Vector2.left * Speed);
            _renderer.flipX = true;
        }
        else
        {
            _animator.SetFloat("run", 0);
            _rigidbody2D.AddForce(Vector2.zero);
        }

        _canJump = IsGrounded();


        if (Input.GetKey(jumpKey) && _canJump)
        {
            _animator.SetFloat("jump", JumpForce);
            _rigidbody2D.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
            _jumpCompleted = false;
        }

        if (_canJump && _jumpCompleted)
            _animator.SetFloat("jump", 0);
    }

    private bool IsGrounded()
    {
        var hit = Physics2D.Raycast(transform.position, -Vector2.up, 1f, ground);

        if (!hit) return false;
        if (!hit.collider.gameObject.CompareTag("Ground")) return true;
        _jumpCompleted = true;
        return true;
    }
}