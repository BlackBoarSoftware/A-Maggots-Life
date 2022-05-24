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
    [SerializeField] Animator animator;
    AudioSource audioSource;
    bool isDead = false; //for now only used to disable movement

    public bool isActive = true;

    Vector2 moveDirection;
    Vector2 rawInput;
    bool isJumping;
    bool isDodging = false;
    bool facingLeft = true;
    Rigidbody2D rb;


    const string platformLayer = "Platform";

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if(isDead) 
        {
            rb.velocity = new Vector2(0,0);
            return;
        }
        //Move the player
        else if (isDodging)
        {
            rb.velocity = new Vector2(rawInput.x * (moveSpeed + dodgeMagnitude), rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(rawInput.x * moveSpeed, rb.velocity.y);
        }
        /* #region  Flipping Logic*/
        if (rawInput.x > 0 && facingLeft) //if moving right and facing left, flip
        {
            Flip();
        }
        else if (rawInput.x < 0 && !facingLeft) //if moving right and facing left, flip
        {
            Flip();
        }
        /* #endregion */

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));


        //Make the player jump
        if (isJumping)
        {
            rb.velocity += new Vector2(0f, jumpForce);
            isJumping = false;
        }
    }
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingLeft = !facingLeft;
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
        if (!isActive) { return; }
        isDodging = true;
        animator.SetBool("isDodging", true);
        Invoke("EndDodge", dodgeBoostLength);
    }

    void EndDodge()
    {
        isDodging = false;
        animator.SetBool("isDodging", false);
    }

    //Death
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Birb")
        {
            isDead = true;
            audioSource.Play();
            Debug.Log("You got vored");
            animator.SetBool("isDead", true);
            Invoke("OnDeathAnimEnd", 2f);
        }
    }

    void OnDeathAnimEnd()
            {
                Destroy(gameObject);
            }
}
