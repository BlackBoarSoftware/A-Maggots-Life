using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Quit : MonoBehaviour
{
    void OnQuit(InputValue value)
    {
        Debug.Log("quitting");
        Application.Quit();
    }
}
