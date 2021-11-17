using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWalker : MonoBehaviour
{
    private Vector2 thisPosition;
    [SerializeField] Vector2 velocidad;
    private float timer;

    private void Start()
    {
        thisPosition = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.position = new Vector3(thisPosition.x, thisPosition.y);
        thisPosition += (velocidad * (Time.deltaTime));

        if (timer >= 25f)
        {
            Destroy(gameObject);
        }
    }
}
