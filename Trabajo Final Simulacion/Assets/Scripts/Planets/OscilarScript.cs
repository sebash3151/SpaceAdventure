using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilarScript : MonoBehaviour
{
    [Header("Valores X")]
    [SerializeField] float amplitudX;
    [SerializeField] [Range(0, 5)] float periodoX;
    float x;

    [Header("Valores Y")]
    [SerializeField] float amplitudY;
    [SerializeField] [Range(0, 5)] float periodoY;
    float y;

    [Header("CheckBoxes")]
    [SerializeField] bool aleatorizar = false;
    [SerializeField] bool oscilar = false;

    private void Start()
    {
        if (aleatorizar)
        {
            Aleatorizador();
        }
    }

    void Update()
    {
        if (oscilar)
        {
            Oscilador();
        }    
    }

    private void Oscilador()
    {
        if (periodoX != 0)
        {
            float factorX = Time.time / periodoX;
            x = amplitudX * Mathf.Sin(2 * Mathf.PI * factorX);
        }
        if (periodoY != 0)
        {
            float factorY = Time.time / periodoY;
            y = amplitudY * Mathf.Sin(2 * Mathf.PI * factorY);
        }
        transform.position = new Vector3(x, y, transform.position.z); //+ transform.position.x, y + transform.position.y, transform.position.z
    }

    private void Aleatorizador()
    {
        amplitudX = Random.Range(0f, 2f);
        amplitudY = Random.Range(0f, 2f);
        periodoY = Random.Range(0f, 2f);
        periodoX = Random.Range(0f, 2f);
    }

}
