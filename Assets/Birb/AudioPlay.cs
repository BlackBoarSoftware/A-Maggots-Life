using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    private void OnEnable() 
    {
        audioSource.Play();
    }
}
