using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] GameObject winHud;
    [SerializeField] string sceneName;
    [SerializeField] GameObject resetButon;
    [SerializeField] GameManager manager;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            manager.win = true;
            audio.Play();
            resetButon.SetActive(false);
            winHud.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
}
