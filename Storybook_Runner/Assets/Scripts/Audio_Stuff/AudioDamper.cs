using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDamper : MonoBehaviour
{

    public AudioSource audioSource;
    






    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    public void AudioLower()
    {
        audioSource.pitch = 0.8f;
        audioSource.volume = 0.5f;
    }


   
}
