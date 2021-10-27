using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilarScript : MonoBehaviour
{
    [Header("Valores X")]
    [SerializeField] [Range(0, 3)] float amplitudX;
    [SerializeField] [Range(0, 3)] float periodoX;
    float x;

    [Header("Valores Y")]
    [SerializeField] [Range(0, 3)] float amplitudY;
    [SerializeField] [Range(0, 3)] float periodoY;
    float y;

    private void Start()
    {
        Aleatorizador();
    }

    void Update()
    {
        Oscilador();       
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
        transform.position = new Vector3(x, y, transform.position.z);
    }

    private void Aleatorizador()
    {
        amplitudX = Random.Range(0f, 4f);
        amplitudY = Random.Range(0f, 4f);
        periodoY = Random.Range(0f, 4f);
        periodoX = Random.Range(0f, 4f);
    }

}
