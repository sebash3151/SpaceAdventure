using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionActivation : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] int OFriccion1AceleracionLocal;
    SpriteRenderer render;
    AudioSource audio;
    [SerializeField] AudioClip slowAudio, fastAudio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        render = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (OFriccion1AceleracionLocal == 0)
        {
            audio.clip = slowAudio;
            GameObject child = transform.GetChild(0).gameObject;
            child.SetActive(true);
            GameObject temp = transform.GetChild(2).gameObject;
            temp.SetActive(false);
        }
        else
        {
            audio.clip = fastAudio;
            GameObject child = transform.GetChild(1).gameObject;
            child.SetActive(true);
            GameObject temp = transform.GetChild(2).gameObject;
            temp.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Player"))
        {
            audio.Play();
            WaterFriction friction = collision.GetComponent<WaterFriction>();
            friction.OFriccion1Aceleracion = OFriccion1AceleracionLocal;
            friction.Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            WaterFriction friction = collision.GetComponent<WaterFriction>();
            friction.DeActivate();
        }
    }
}
