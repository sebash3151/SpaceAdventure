using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandonBackSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] objetos;
    private float spawnTime;
    [SerializeField] private float minimunSpawnTime, maximunSpawnTime;
    Transform[] puntos;
    private float timer;
    private bool[] confirm;
    private int puntRan, objRan;

    private void Start()
    {
        puntos = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            puntos[i] = child.GetComponentInChildren<Transform>();
        }

        confirm = new bool[objetos.Length];
        for (int i = 0; i < objetos.Length; i++)
        {
            confirm[i] = false;
        }

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            Ranmdomizer();
            Aleatorio();
            spawnTime = Random.Range(minimunSpawnTime, maximunSpawnTime);
        }
    }

    private void Aleatorio()
    {
        if(objRan == 0 && confirm[objRan] == false)
        {
            puntRan = Random.Range(0, 5);
            Instantiate(objetos[objRan], puntos[puntRan]);
            BoolCancel(objRan);
            timer = 0f;
            return;
        }
        else if(objRan == 1 && confirm[objRan] == false)
        {
            puntRan = Random.Range(5, 10);
            Instantiate(objetos[objRan], puntos[puntRan]);
            BoolCancel(objRan);
            timer = 0f;
            return;
        }
        else if(objRan == 2 && confirm[objRan] == false)
        {
            puntRan = Random.Range(5, 10);
            Instantiate(objetos[objRan], puntos[puntRan]);
            BoolCancel(objRan);
            timer = 0f;
            return;
        }
        Ranmdomizer();
    }

    private void Ranmdomizer()
    {
        objRan = Random.Range(0, objetos.Length);        
    }

    private void BoolCancel(int active)
    {
        for (int i = 0; i < confirm.Length; i++)
        {
            confirm[i] = false;
        }
        confirm[active] = true;
    }
}
