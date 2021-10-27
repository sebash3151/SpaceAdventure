using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public VectorPoderoso thisPosition, velocidad, aceleracion;
    [SerializeField] Color color, color2, color3;
    [SerializeField] float xmax = 5f, xmin = -5, ymax = 5, ymin = -5, rapidezlimite = 5f;
    VectorPoderoso velocidadaplicada, aceleracionaplicada, objetivocopia, ubicacionActual;
    [SerializeField] float velocidadPerdida = 0f;
    [SerializeField] VectorPoderoso objetivo = new VectorPoderoso();
    [SerializeField] Transform objetivotrans;
    [SerializeField] bool boxlimits = true;

    private void Start()
    {
        thisPosition.X = this.transform.position.x;
        thisPosition.Y = this.transform.position.y;
    }

    void Update()
    {
        HallarObjetivo();
        UpdatePosition();
        thisPosition.DibujarVector(color);
        velocidad.DibujarVectorDiferente(thisPosition.X, thisPosition.Y, color2);
        aceleracion.DibujarVectorDiferente(thisPosition.X, thisPosition.Y, color3);
        transform.position = new Vector3(thisPosition.X, thisPosition.Y);
    }

    public void UpdatePosition()
    {
        velocidadaplicada = new VectorPoderoso(velocidad.X, velocidad.Y);
        aceleracionaplicada = new VectorPoderoso(aceleracion.X, aceleracion.Y);
        objetivocopia = new VectorPoderoso(objetivo.X, objetivo.Y);
        ubicacionActual = new VectorPoderoso(this.transform.position.x, this.transform.position.y);

        aceleracion = objetivocopia.Resta(ubicacionActual);

        velocidad.Suma(aceleracionaplicada.Multiplicar(Time.deltaTime));
        if (velocidad.CalcularMagnitud() > rapidezlimite)
        {
            velocidad = velocidad.Normalizar();
            velocidad.Multiplicar(rapidezlimite);
        }

        thisPosition.Suma(velocidadaplicada.Multiplicar(Time.deltaTime));

        if (boxlimits)
        {
            BoxLimitsCollision();
        }
        
    }

    private void PerderVelocidad()
    {
        velocidad.Multiplicar(velocidadPerdida);
    }

    private void BoxLimitsCollision()
    {
        if (thisPosition.X > xmax)
        {
            thisPosition.X = xmax;
            velocidad.X = -velocidad.X;
            PerderVelocidad();
        }
        else if (thisPosition.X < xmin)
        {
            thisPosition.X = xmin;
            velocidad.X = -velocidad.X;
            PerderVelocidad();
        }
        if (thisPosition.Y > ymax)
        {
            thisPosition.Y = ymax;
            velocidad.Y = -velocidad.Y;
            PerderVelocidad();
        }
        else if (thisPosition.Y < ymin)
        {
            thisPosition.Y = ymin;
            velocidad.Y = -velocidad.Y;
            PerderVelocidad();
        }
    }

    private void HallarObjetivo()
    {
        objetivo.X = objetivotrans.position.x;
        objetivo.Y = objetivotrans.position.y;
    }
}
