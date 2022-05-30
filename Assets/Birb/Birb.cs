using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birb : MonoBehaviour
{
    Animator myAnim;
    [SerializeField] float waitTime;
    [SerializeField] [Range(0f,1f)] float animationOffset; //used for variation in the timing among enemies.
    private void OnEnable() 
    {
        myAnim = GetComponent<Animator>();
        myAnim.SetFloat("WaitTime", 1 / waitTime); //allows us to enter time in seconds for animation length
        myAnim.Play("Birb_WaitTime", -1, animationOffset);//enemy timing variation
    }
}
