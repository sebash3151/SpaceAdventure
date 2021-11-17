using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackScroller : MonoBehaviour
{
    public float scrollspeed;
    Vector2 StartPos;

    void Start()
    {
        StartPos = transform.position;       
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollspeed, 400);
        transform.position = StartPos + Vector2.right * newPosition;
    }
}
