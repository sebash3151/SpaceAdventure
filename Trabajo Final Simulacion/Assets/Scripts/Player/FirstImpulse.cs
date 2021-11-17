using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstImpulse : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject flecha;
    [SerializeField] GameObject player;
    [SerializeField] float indiceDesacelere;
    bool desacelere;
    Walker walker;
    Vector2 mousePosition;
    Vector2 thisPosicion;
    Vector2 posicionALanzar;
    WaterFriction friction;
    AudioSource audio;
    bool sonido = false;
    Vector2 impulso;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        friction = player.GetComponent<WaterFriction>();        
        walker = player.GetComponent<Walker>();
    }

    void Update()
    {
        flecha.transform.position = player.transform.position + new Vector3(1f, 1f, 0f);
        if (gameManager.preparation)
        {
            walker.acelerate = false;
            flecha.SetActive(true);
            Apuntar();
            sonido = false;
        }
        else if (gameManager.playing)
        {
            if (!sonido)
            {
                audio.Play();
                sonido = true;
            }

            flecha.SetActive(false);
            ImpulsoInicial();
            LoseVelocity();
        }
    }

    private void ImpulsoInicial()
    {        
        if (!walker.acelerate && !friction.fluidoEnter && !desacelere)
        {
            impulso = posicionALanzar;

            walker.velocidad = impulso;
            desacelere = true;
        }
    }

    private void LoseVelocity()
    {
        if(!walker.acelerate && !friction.fluidoEnter && desacelere)
        {
            walker.velocidad = walker.velocidad - walker.velocidad.normalized * indiceDesacelere;
        }
    }

    private void Apuntar()
    {
        thisPosicion = flecha.transform.position;
        mousePosition = GetWorldMousePosition();
        posicionALanzar = mousePosition - thisPosicion;
        RotateZ(LookAtOMG(posicionALanzar));
        Escalar();
    }

    private void Escalar()
    {
        flecha.transform.localScale = new Vector2(posicionALanzar.magnitude, 1f);
        if (flecha.transform.localScale.x >= 3)
        {
            flecha.transform.localScale = new Vector2(3f, 1f);
        }
    }

    private float LookAtOMG(Vector2 target)
    {
        float direccion = Mathf.Atan2(target.y, target.x);
        return (direccion);
    }

    private Vector2 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        Vector2 posicionFinal = new Vector2(worldPos.x, worldPos.y);
        return posicionFinal;
    }

    private void RotateZ(float radians)
    {
        flecha.transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}
