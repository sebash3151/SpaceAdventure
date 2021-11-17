using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    GameManager manager;
    [SerializeField] AudioClip clipLevel, clipWin;
    AudioSource audio;
    private int i = 0, j = 0;

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
                audio.clip = clipLevel;
                audio.Play();
                i++;
            }
        }
        if (manager.win)
        {
            if (j == 0)
            {
                audio.clip = clipWin;
                audio.Play();
                j++;
            }
        }
    }
}
