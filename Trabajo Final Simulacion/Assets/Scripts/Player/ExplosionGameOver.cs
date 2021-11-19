using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionGameOver : MonoBehaviour
{
    Walker walker;
    [SerializeField] GameManager manager;
    AudioSource audio;
    [SerializeField] AudioSource levelAudio;
    [SerializeField] GameObject explosion, llamas, flecha;
    SpriteRenderer renderSprite;
    [SerializeField] GameObject slider;
    private Scrollbar sliderUI;
    private int song = 0;

    void Awake()
    {
        sliderUI = slider.GetComponent<Scrollbar>();
        renderSprite = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
        walker = GetComponent<Walker>();
    }

    void Update()
    {
        if (walker.velocidad.magnitude <= 1f && manager.playing)
        {
            slider.SetActive(true);
            sliderUI.size = walker.velocidad.magnitude;
        }
        else if(walker.velocidad.magnitude > 1f)
        {
            slider.SetActive(false);
        }

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
        Sonar();
    }

    private void Sonar()
    {
        if(song == 0)
        {
            audio.Play();
            song++;
        }
    }
}
