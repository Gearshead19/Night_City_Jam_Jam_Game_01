using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHitSFX : MonoBehaviour
{
    public AudioSource playSFX;


    // Start is called before the first frame update
    void Start()
    {
        playSFX = GetComponent<AudioSource>();
    }

    public void ObstacleHitSFXPlay()
    {
        playSFX.Play();
    }
}
