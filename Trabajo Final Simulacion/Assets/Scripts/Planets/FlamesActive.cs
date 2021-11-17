using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamesActive : MonoBehaviour
{
    [SerializeField] GameObject flames;
    [SerializeField] GameManager manager;

    void Update()
    {
        if (manager.playing)
        {
            flames.SetActive(true);
        }
        else
        {
            flames.SetActive(false);
        }
    }
}
