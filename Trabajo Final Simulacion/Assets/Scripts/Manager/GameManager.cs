using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    public bool preparation = false, playing = false, win = false;
    [SerializeField] GameObject startHUD;

    MyCustomLookAt playerLook;
    Walker walker;

    void Start()
    {
        startHUD.SetActive(true);
        playerLook = player.GetComponent<MyCustomLookAt>();
        walker = player.GetComponent<Walker>();
    }

    void Update()
    {
        if (preparation && Input.GetButtonDown("Fire1"))
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

    public void Preparate()
    {
        preparation = true;
        playing = false;
        walker.enabled = false;
        playerLook.observacion = true;
    }
}
