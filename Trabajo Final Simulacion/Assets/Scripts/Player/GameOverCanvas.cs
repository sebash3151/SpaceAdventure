using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField] GameObject deadCanvas;
    public void PauseTime()
    {
        Time.timeScale = 0f;
        deadCanvas.SetActive(true);
    }
}
