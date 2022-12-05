using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMusic : MonoBehaviour
{
    private void OnEnable()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}