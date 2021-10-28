using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    public bool preparation = true, playing = false;

    MyCustomLookAt playerLook;
    Walker walker;

    void Start()
    {
        playerLook = player.GetComponent<MyCustomLookAt>();
        walker = player.GetComponent<Walker>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameStart();
        }
    }

    private void GameStart()
    {
        preparation = false;
        playing = true;
        playerLook.observacion = false;
        walker.enabled = true;
    }
}
