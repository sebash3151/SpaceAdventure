using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFriction : MonoBehaviour
{
    //fluidos
    public bool fluidoEnter = false;

    public int OFriccion1Aceleracion;
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
            walker.aceleracion = new Vector2(0, 0);
            ModificarVelocidad();
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

    public void Activate()
    {
        fluidoEnter = true;
    }

    public void DeActivate()
    {
        fluidoEnter = false;
        aumento = false;
    }

}
