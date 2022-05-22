using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] Vector3 offset;
    [SerializeField] float fallingSpeed = 30f;
    [SerializeField] float raiseSpeed = 15f;
    [SerializeField] float fallTimeLength = 1f;
    [SerializeField] float raiseTimeLength = 2f;
    bool isAttackStateActivated = false;
    Vector3 newPlayerPosition;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    { 
        if(!isAttackStateActivated)
        {
            transform.position = player.transform.position + offset;
        }
        
        if(isAttackStateActivated)
        {
            Attack();
        }
    }

    public void ActivateAttackState()
    {
        Debug.Log("Attack State Activated");
        isAttackStateActivated = true;
    }

        private void Attack()
    {
        rb.velocity = new Vector2(0f, -fallingSpeed);
        Invoke("Stop", fallTimeLength);
        Invoke("Raise", raiseTimeLength);
        Invoke("Stop", 1f);
        Invoke("Reset", 1f);
    }
    void Stop()
    {
        rb.velocity = new Vector2 (0f, 0f);
    }
    void Raise()
    {
        rb.velocity = new Vector2(0f, raiseSpeed);
    }
    void Reset()
    {
        isAttackStateActivated = false;
    }
}
