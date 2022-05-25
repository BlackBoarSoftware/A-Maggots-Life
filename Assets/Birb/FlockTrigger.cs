using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockTrigger : MonoBehaviour
{
    [SerializeField] GameObject flock;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag.Equals("Player"))
        {
            flock.SetActive(true);
        }    
    }
}
