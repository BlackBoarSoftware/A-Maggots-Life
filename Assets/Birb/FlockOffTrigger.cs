using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockOffTrigger : MonoBehaviour
{
    [SerializeField] GameObject flock;
    [SerializeField] GameObject audioAttack;
    [SerializeField] GameObject audioHorror;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag.Equals("Player"))
        {
            flock.SetActive(false);
            audioAttack.SetActive(false);
            audioHorror.SetActive(false);
        }    
    }
}
