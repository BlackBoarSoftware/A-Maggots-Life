using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float dodgeMagnitude = 8f;
    [SerializeField] float dodgeBoostLength = .1f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Collider2D feet;

    public bool isActive = true;

    Vector2 moveDirection;
    Vector2 rawInput;
    bool isJumping;
    bool isDodging = false;
    Rigidbody2D rb;


    const string platformLayer = "Platform";

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Move the player
        if(isDodging)
        {
            rb.velocity = new Vector2(rawInput.x * (moveSpeed + dodgeMagnitude), rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(rawInput.x * moveSpeed, rb.velocity.y);
        }
        

        //Make the player jump
        if (isJumping)
        {
            rb.velocity += new Vector2(0f, jumpForce);
            isJumping = false;
        }
    }

    //Used by the input system 
    void OnMove(InputValue value)
    {
        if (!isActive) { return; }
        rawInput = value.Get<Vector2>();
    }

    //Used by the input system
    void OnJump(InputValue value)
    {
        if (!isActive) { return; }
        if (!feet.IsTouchingLayers(LayerMask.GetMask(platformLayer))) { return; }

        isJumping = true;
    }

    void OnDodge(InputValue value)
    {
        Debug.Log("dodge");
        if(!isActive) {return;}
        isDodging = true;
        Invoke("EndDodge", dodgeBoostLength);
    }

    void EndDodge()
    {
        isDodging = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Birb")
        {
            Debug.Log("Pecked to death");
            //TODO Play player death FX
            Destroy(gameObject);
        }
    }
}
