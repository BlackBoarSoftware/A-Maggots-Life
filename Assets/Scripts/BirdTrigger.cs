using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTrigger : MonoBehaviour
{
    [SerializeField] Bird bird; 
    private void OnTriggerEnter2D(Collider2D other) 
    {
        bird.ActivateAttackState();
    }
}
