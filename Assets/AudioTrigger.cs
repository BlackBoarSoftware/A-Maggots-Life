using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] GameObject audioAttack;
    [SerializeField] GameObject audioHorror;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag.Equals("Player"))
        {
            audioAttack.SetActive(true);
            audioHorror.SetActive(true);
        }    
    }
}
