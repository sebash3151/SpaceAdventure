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
        if (collision.CompareTag("planet"))
        {
            walker.acelerate = true;
            Transform trans = collision.transform;
            walker.objetivotrans = trans;
        }
    }
}
