using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionActivation : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] int OFriccion1AceleracionLocal;
    [SerializeField] Sprite[] sprites;
    SpriteRenderer render;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (OFriccion1AceleracionLocal == 0)
        {
            render.sprite = sprites[0];
        }else
        {
            render.sprite = sprites[1];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Player"))
        {
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
