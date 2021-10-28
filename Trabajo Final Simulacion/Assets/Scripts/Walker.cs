using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    private Vector2 thisPosition, ubicacionActual;
    public Vector2 velocidad, aceleracion;
    [SerializeField] float rapidezlimite = 5f;
    Vector2 objetivo = new Vector2();
    public Transform objetivotrans;
    public bool acelerate = false;

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

        if (acelerate)
        {
            aceleracion = objetivo - ubicacionActual;
        }

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
