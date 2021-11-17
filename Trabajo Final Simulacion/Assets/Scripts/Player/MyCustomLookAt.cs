using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCustomLookAt : MonoBehaviour
{
    Vector2 thisPosicion;
    Vector2 observar;
    [SerializeField] public bool observacion = true;
    Walker walker;

    Vector2 mousePosition;

    private void Start()
    {
        walker = GetComponent<Walker>();
    }

    void Update()
    {
        thisPosicion = transform.position;
        mousePosition = GetWorldMousePosition();
        Observar();
    }

    private void Observar()
    {
        if (observacion)
        {
            RotateZ(LookAtOMG(mousePosition - thisPosicion));
        }
        else
        {
            RotateZ(LookAtOMG(walker.velocidad));
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
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }

}
