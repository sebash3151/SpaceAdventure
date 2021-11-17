using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetSpriteUI : MonoBehaviour
{
    [SerializeField] Sprite[] planetasSprite;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    void Start()
    {
        image.sprite = planetasSprite[Random.Range(0, planetasSprite.Length)];
    }
}
