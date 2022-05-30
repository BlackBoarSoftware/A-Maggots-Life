using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("PlayNextScene", 16f);
    }

    void PlayNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
