using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    GameManager manager;
    [SerializeField] AudioClip clip;
    AudioSource audio;
    private int i = 0;

    private void Awake()
    {
        manager = GetComponent<GameManager>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (manager.playing)
        {
            if (i == 0)
            {
                audio.clip = clip;
                audio.Play();
                i++;
            }
        }
    }
}
