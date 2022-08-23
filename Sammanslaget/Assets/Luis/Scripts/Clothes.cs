using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : MonoBehaviour
{
    public static Clothes Instance { get; private set; }

    //[HideInInspector] 
    public Sprite[] trendSprites, shopSprites, recyclingSprites;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        GetSpritesLists();
    }    

    public int RandomizeClothingSprite(Sprite[] sprites)
    {
        int clothingNumber = Random.Range(0, sprites.Length);

        return clothingNumber;
    }

    public void SetClothingSprite(SpriteRenderer spriteRenderer, Sprite[] sprites)
    {
        spriteRenderer.sprite = sprites[RandomizeClothingSprite(sprites)];
    }

    public void GetSpritesLists()
    {
        trendSprites = Resources.LoadAll<Sprite>("TrendSprites");
        shopSprites = Resources.LoadAll<Sprite>("ShopSprites");
        recyclingSprites = Resources.LoadAll<Sprite>("RecyclingSprites");
    }

}
