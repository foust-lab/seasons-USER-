using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioPitchRandom : MonoBehaviour
{
    public AudioSource song;

    public float pitchRangeMax = .5f;
    public float pitchRangeMin = -.5f;
    public float timeChanfge = .5f;

    float pitch;
   
    private void Start()
    {
        pitch = pitchRangeMax;
    }

    void Update()
    {

        
        if (pitch == pitchRangeMax)
        {
            pitch = Mathf.Lerp(pitch, pitchRangeMin, timeChanfge);
        }
        if (pitch == pitchRangeMin)
        {
            pitch = Mathf.Lerp(pitch, pitchRangeMax, timeChanfge);
        }



        song.pitch = pitch;
         
    }
}
