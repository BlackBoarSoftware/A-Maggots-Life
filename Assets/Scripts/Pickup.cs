using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Score score;
    bool isColliding = false;

    /*
    We use a coroutine to and a boolean state to ensure that the code inside the else statement in OnTriggerEnter gets called only once.
    The coroutine waits for the next frame until it resets the isColliding State.
    The problem was that physics get calculated before the frame refresh, and sometimes the collider will trigger more than once before Destroy(). This coroutine 
    disables the pickup functionality after its been triggered once, while it gives the game time to destroy the object.

    TODO get object from collision and execute only if it is player.
    */
    void OnTriggerEnter2D (Collider2D other)
    {
        if(isColliding) {return;}
        else
        {
            ExecutePickup();
        }

        StartCoroutine(Reset());
    }

    private void ExecutePickup()
    {
        isColliding = true;
        score = FindObjectOfType<Score>();
        score.AddScore();
        Destroy(gameObject);
    }

    IEnumerator Reset()
    {
        yield return new WaitForEndOfFrame();
        isColliding = false;
    }
}
