using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCustomLookAt : MonoBehaviour
{
    [SerializeField] Color color;
    Vector2 thisPosicion;
    [SerializeField] float speed = 5f;
    Vector2 observar;
    [SerializeField] bool observacion = false;
    [SerializeField] bool moverseSinAcelerar = false;
    Vector2 velocity = new Vector2(0, 0);

    [Header("Acelerar")]
    [SerializeField] bool moverseConAcelerar = false;
    [SerializeField] Vector2 aceleracion;
    Vector2 mousePosition;

    void Update()
    {
        thisPosicion = transform.position;
        mousePosition = GetWorldMousePosition();
        ObservarA();
        Impulso();
        ImpulsoAcelerado();
    }

    private void Impulso()
    {
        if (moverseSinAcelerar)
        {
            observar = mousePosition - thisPosicion;
            observar.Normalize();
            Vector2 velocity = observar * speed;
            Vector3 finalPosition = new Vector3(velocity.x, velocity.y, 0);
            RotateZ(LookAtOMG(velocity)); 
            transform.position += finalPosition * Time.deltaTime;
        }
    }
    private void ImpulsoAcelerado()
    {
        if (moverseConAcelerar)
        {
            aceleracion = mousePosition - thisPosicion;
            velocity += (aceleracion * Time.deltaTime);
            Vector3 finalPosition = new Vector3(velocity.x, velocity.y, 0);

            RotateZ(LookAtOMG(velocity));
            transform.position += (finalPosition * Time.deltaTime);
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

    private void ObservarA()
    {
        if (observacion)
        {
            RotateZ(LookAtOMG(mousePosition - thisPosicion));
        }
    }
}
