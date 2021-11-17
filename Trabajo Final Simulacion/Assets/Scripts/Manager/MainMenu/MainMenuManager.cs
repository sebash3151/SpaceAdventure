using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] AudioClip click;
    [SerializeField] AudioClip back;
    [SerializeField] AudioClip bye;
    [SerializeField] AudioClip welcome;
    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        audio.clip = welcome;
        audio.Play();
        ChangeScene();
    }

    public void ExitGame()
    {
        audio.clip = bye;
        audio.Play();
        Exit();
    }

    public void Click()
    {
        audio.clip = click;
        audio.Play();
    }

    public void Back()
    {
        audio.clip = back;
        audio.Play();
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Level1()
    {
        sceneName = "Level1";
        StartGame();
    }
    public void Level2()
    {
        sceneName = "Level2";
        StartGame();
    }
    public void Level3()
    {
        sceneName = "Level3";
        StartGame();
    }
}
