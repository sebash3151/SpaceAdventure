using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstImpulse : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject flecha;
    [SerializeField] GameObject player;
    [SerializeField] Color color;
    Walker walker;
    Vector2 mousePosition;
    Vector2 thisPosicion;

    private void Start()
    {
        flecha.transform.position = player.transform.position + new Vector3(1f, 1f, 0f);
        walker = player.GetComponent<Walker>();
    }

    void Update()
    {
        if (gameManager.preparation)
        {
            flecha.SetActive(true);
            Apuntar();
        }
        else if (gameManager.playing)
        {
            flecha.SetActive(false);
            ImpulsoInicial();
        }
    }

    private void ImpulsoInicial()
    {
        if (!walker.acelerate)
        {
            float magnitud = mousePosition.magnitude * 10f;
            if (magnitud >= 30f)
            {
                magnitud = 30f;
            }
            Vector2 direccion = mousePosition.normalized;
            Vector2 impulso = direccion * magnitud;
            //Debug.DrawLine(flecha.transform.position, impulso, color);
            walker.velocidad = impulso;
        }
    }

    private void Apuntar()
    {
        thisPosicion = flecha.transform.position;
        mousePosition = GetWorldMousePosition();
        RotateZ(LookAtOMG(mousePosition - thisPosicion));
        Escalar();
    }

    private void Escalar()
    {
        flecha.transform.localScale = new Vector2(Mathf.Abs(mousePosition.x), 1f);
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
