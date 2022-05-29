using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class PulsingPPFX : MonoBehaviour
{
    [SerializeField] Volume volume;
    ChromaticAberration chromaticAberration;

    private void Start() 
    {
        volume.profile.TryGet(out chromaticAberration);
    }
    private void Update() 
    {
        chromaticAberration.intensity.value = Mathf.Sin(Time.realtimeSinceStartup*4);    
    }
}
