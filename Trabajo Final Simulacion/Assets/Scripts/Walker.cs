using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public Vector2 thisPosition, velocidad, aceleracion, ubicacionActual;
    [SerializeField] float  rapidezlimite = 5f;
    [SerializeField] Vector2 objetivo = new Vector2();
    [SerializeField] public Transform objetivotrans;

    private void Start()
    {
        thisPosition = transform.position;
    }

    void Update()
    {
        HallarObjetivo();
        UpdatePosition();
        transform.position = new Vector3(thisPosition.x, thisPosition.y);
    }

    public void UpdatePosition()
    {
        ubicacionActual = new Vector2(this.transform.position.x, this.transform.position.y);

        aceleracion = objetivo - ubicacionActual;

        velocidad += aceleracion * (Time.deltaTime);

        if (velocidad.magnitude > rapidezlimite)
        {
            var velocidadNormalizada = velocidad.normalized;
            velocidad = velocidadNormalizada * (rapidezlimite);
        }
        thisPosition += (velocidad * (Time.deltaTime));        
    }

    private void HallarObjetivo()
    {
        objetivo = objetivotrans.position;
    }
}
