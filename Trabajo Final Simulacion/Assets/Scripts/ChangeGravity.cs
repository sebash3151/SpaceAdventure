using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    Walker walker;

    void Start()
    {
        walker = GetComponent<Walker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("entro");
        if (collision.CompareTag("planet"))
        {
            Transform trans = collision.transform;
            walker.objetivotrans = trans;
        }
    }
}
