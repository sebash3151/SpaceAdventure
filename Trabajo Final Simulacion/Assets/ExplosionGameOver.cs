using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGameOver : MonoBehaviour
{
    Walker walker;
    [SerializeField] GameManager manager;

    void Awake()
    {
        walker = GetComponent<Walker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walker.velocidad.magnitude <= 0.1f && manager.playing)
        {
            Destroy(gameObject);
        }
    }
}
