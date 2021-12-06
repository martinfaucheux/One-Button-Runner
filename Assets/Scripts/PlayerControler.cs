using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // PUBLIC
    public float jumpForce = 10f;
    public float jumpTime = 0.35f;
    public float moveSpeed = 8;
    public KeyCode keyCode;
    public Transform feetTransform;
    public float checkRadius = 0.3f;
    public LayerMask whatIsGround;
    public ShurikenSpawner shurikenSpawner;

    public float crashForce = 400f;
    public float crashFriction = 0.02f;

    // PRIVATE
    private Rigidbody2D _rigidBody;
    private bool _isGrounded = true;
    private float _jumpTimeCounter;
    private bool _isJumping = false;
    private float _yVelocity;
    private bool _isDead = false;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _yVelocity = _rigidBody.velocity.y;
        bool wasGrounded = _isGrounded;
        _isGrounded = Physics2D.OverlapCircle(feetTransform.position, checkRadius, whatIsGround);

        if (!wasGrounded && _isGrounded)
        {
            shurikenSpawner.Recharge();
        }

        if (Input.GetKeyDown(keyCode))
        {

            if (_isGrounded)
            {
                _isJumping = true;
                _jumpTimeCounter = jumpTime;
                _yVelocity = jumpForce;
            }
            else if (shurikenSpawner.HasShurikenLeft())
            {
                _isJumping = true;
                _jumpTimeCounter = jumpTime;
                _yVelocity = jumpForce;
                shurikenSpawner.Spawn();
            }
        }

        // The player is still holding the button while jumping
        else if (Input.GetKey(keyCode) && _isJumping)
        {
            if (_jumpTimeCounter > 0)
            {
                _yVelocity = jumpForce;
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                // max height reached
                _isJumping = false;
            }
        }

        // player cancelled the jump
        if (Input.GetKeyUp(keyCode))
        {
            _isJumping = false;
        }

        if (!_isDead)
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.right;
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = _rigidBody.velocity;
        velocity.y = _yVelocity;
        _rigidBody.velocity = velocity;
    }

    public void Die()
    {
        _isDead = true;
        GetComponent<Collider2D>().sharedMaterial.friction = crashFriction;
        _rigidBody.AddForce(crashForce * Vector2.right);
        GameEvents.instance.GameOverTrigger();
        Destroy(this);
    }

}
