using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpriteChange : MonoBehaviour
{
    [SerializeField] Sprite[] planetasSprite;
    private SpriteRenderer render;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        render.sprite = planetasSprite[Random.Range(0, planetasSprite.Length)];
    }

}
