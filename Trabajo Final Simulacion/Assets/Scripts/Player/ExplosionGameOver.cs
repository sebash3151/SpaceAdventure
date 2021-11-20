using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionGameOver : MonoBehaviour
{
    public bool IsDead {
        get;
        private set;
    }

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
        // Does nothing else if already dead
        if (IsDead)
        { 
            return; 
        }

        if (walker.velocidad.magnitude <= 1f && manager.playing)
        {
            slider.SetActive(true);
            sliderUI.size = walker.velocidad.magnitude;
        }
        else if(walker.velocidad.magnitude > 1f)
        {
            slider.SetActive(false);
        }

        // We are assuming velocity is zero only when the ship is in preparation or static state...
        // This zero check is used to wait until the ship is again moving and avoiding race conditions with other MonoBehaviour updates.
        if (walker.velocidad != Vector2.zero && walker.velocidad.magnitude <= 0.1f && manager.playing && !walker.acelerate)
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
        //walker.velocidad = new Vector2(0, 0);
        levelAudio.pitch = 0.7f;
        IsDead = true;
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
