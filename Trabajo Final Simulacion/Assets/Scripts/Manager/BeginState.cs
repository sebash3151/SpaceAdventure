using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginState : MonoBehaviour
{
    [SerializeField] GameManager manager;
    [SerializeField] MyCustomLookAt look;
    [SerializeField] FirstImpulse impulse;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();   
    }

    public void Begin()
    {
        look.enabled = true;
        impulse.enabled = true;
        audio.Play();
        manager.preparation = true;
    }
}
