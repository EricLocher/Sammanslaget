using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trend : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Clothes.Instance.SetClothingSprite(spriteRenderer, Clothes.Instance.trendSprites);
    }
}
