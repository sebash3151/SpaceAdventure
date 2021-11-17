using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginState : MonoBehaviour
{
    [SerializeField] GameManager manager;
    [SerializeField] GameObject firstScreen;
    [SerializeField] MyCustomLookAt look;
    [SerializeField] FirstImpulse impulse;
    [SerializeField] GameObject resetButon;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();   
    }

    public void Begin()
    {
        resetButon.SetActive(true);
        look.enabled = true;
        impulse.enabled = true;
        firstScreen.SetActive(false);
        audio.Play();
        manager.preparation = true;
    }
}
