using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicKontrol : MonoBehaviour
{
    AudioSource OyunIciSes;
    void Start()
    {
        OyunIciSes = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        PlayerPrefs.SetFloat("OyunIciSes",OyunIciSes.volume);
    }
    
}
