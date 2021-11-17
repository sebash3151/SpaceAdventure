using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] GameManager manager;
    [SerializeField] Sprite offSprite;
    private AudioSource audio;
    [SerializeField] SpriteRenderer render;
    private bool aterrizaje;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !aterrizaje)
        {
            aterrizaje = true;
            render.sprite = offSprite;
            audio.Play();
            manager.Preparate();
        }
    }
}
