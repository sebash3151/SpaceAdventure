using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject camera;
    [SerializeField] float cameraSize;
    private float actualSize;
    private Camera cameraCa;
    [SerializeField] Transform cameraPoint;
    private bool pauseState = false;
    private AudioSource audio;
    CameraFollow cameraFollow;
    [SerializeField] private Transform actualPos;

    void Start()
    {
        Time.timeScale = 1f;
        cameraCa = camera.GetComponent<Camera>();
        cameraFollow = camera.GetComponent<CameraFollow>();
        audio = GetComponent<AudioSource>();
    }

    public void PauseButton()
    {
        actualSize = cameraCa.orthographicSize;
        cameraCa.orthographicSize = cameraSize;
        actualPos.position = camera.transform.position;
        camera.transform.position = cameraPoint.position;
        cameraFollow.enabled = false;
        audio.Play();
        pauseState = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        cameraCa.orthographicSize = actualSize;
        camera.transform.position = actualPos.position;
        cameraFollow.enabled = true;
        audio.Play();
        pauseState = false;
        Time.timeScale = 1f;
    }
}
