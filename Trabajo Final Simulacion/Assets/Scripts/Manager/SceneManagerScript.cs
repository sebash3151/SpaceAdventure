using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] GameObject winHud;
    [SerializeField] string sceneName;
    [SerializeField] GameObject resetButon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
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
