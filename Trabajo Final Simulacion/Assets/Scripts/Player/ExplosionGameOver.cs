using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGameOver : MonoBehaviour
{
    Walker walker;
    [SerializeField] GameManager manager;
    AudioSource audio;
    [SerializeField] AudioSource levelAudio;
    [SerializeField] GameObject explosion, llamas, flecha;
    SpriteRenderer renderSprite;

    void Awake()
    {
        renderSprite = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
        walker = GetComponent<Walker>();
    }

    void Update()
    {
        if (walker.velocidad.magnitude <= 0.1f && manager.playing && !walker.acelerate)
        {
            Dead();            
        }
    }

    public void Dead()
    {
        flecha.SetActive(false);
        llamas.SetActive(false);
        renderSprite.enabled = false;
        explosion.SetActive(true);
        walker.velocidad = new Vector2(0, 0);
        levelAudio.pitch = 0.7f;
        audio.Play();
    }
}
