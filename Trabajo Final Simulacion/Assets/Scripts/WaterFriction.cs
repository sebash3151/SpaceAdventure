using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFriction : MonoBehaviour
{
    //fluidos
    [SerializeField] float rho = 0f;
    [SerializeField] bool fluidoEnter = false;
    [SerializeField] float areaContacto = 0f;
    [SerializeField] [Range(0, 1)] float coeficienteFriccionFluido = 1f;

    [SerializeField] [Range(0,1)] int OFriccion1Aceleracion;
    [SerializeField] bool aumento = false;

    Walker walker;

    private void Start()
    {
        walker = GetComponent<Walker>();
    }

    private void Update()
    {
        if (fluidoEnter)
        {
            Vector2 fuerzaFluido = new Vector2(0f, 0f);
            Vector2 velocidadNormalizada = walker.velocidad.normalized;
            float cuadradoV = Mathf.Pow(walker.velocidad.magnitude, 2);
            fuerzaFluido = velocidadNormalizada * ((-1f / 2f) * rho * cuadradoV * coeficienteFriccionFluido * areaContacto);
            //walker.acelerate = false;
            walker.aceleracion = new Vector2(0, 0);
            ModificarVelocidad();
            //Debug.Log(fuerzaFluido);
            //walker.velocidad = walker.velocidad - fuerzaFluido;
        }
    }

    private void ModificarVelocidad()
    {
        if (!aumento)
        {
            if (OFriccion1Aceleracion == 0)
            {
                walker.velocidad = walker.velocidad / 2;
                aumento = true;
            }
            if (OFriccion1Aceleracion == 1)
            {
                walker.velocidad = walker.velocidad * 2;
                aumento = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            fluidoEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            fluidoEnter = false;
            aumento = false;
            walker.acelerate = true;
        }
    }
}
