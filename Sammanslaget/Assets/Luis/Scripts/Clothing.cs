using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClothingType
{
    Shop,
    Trend,
    Recycling,
}

public enum TrendType
{
    Y2K,
    Athleisure,
    Puffarm,
    Oversize,
    DarkAcademia,
    //Skate,
    //Grandma,
    //ScandiChic,
    //KPop,
    //Cargo,
    //Bohemia,
    //CottageCore,
    None,
}

public class Clothing : MonoBehaviour
{
    public ClothingType clothingType;
    public TrendType trendType;

    [SerializeField] 
    private Sprite[] trendSprites, shopSprites, recyclingSprites;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {        
        GetSpritesLists();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }    

    public void SetClothingSprite()
    {
        //Sets a random clothingType
        clothingType = (ClothingType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(ClothingType)).Length);

        switch (clothingType)
        {
            case ClothingType.Shop:
                {
                    trendType = TrendType.None;
                    spriteRenderer.sprite = shopSprites[RandomizeClothingSprite(shopSprites)];
                    break;
                }
            case ClothingType.Trend:
                {
                    // The enum type corresponding non-trend clothes it´s at the end of the list, that is why we substract 1 to the length of the enum
                    int trend = UnityEngine.Random.Range(0, Enum.GetNames(typeof(TrendType)).Length - 1);

                    trendType = (TrendType)trend;
                    spriteRenderer.sprite = trendSprites[trend];
                    break;
                }
            case ClothingType.Recycling:
                {
                    trendType = TrendType.None;
                    spriteRenderer.sprite = recyclingSprites[RandomizeClothingSprite(recyclingSprites)];
                    break;
                }
        }
    }

    private int RandomizeClothingSprite(Sprite[] sprites)
    {
        int clothingNumber = UnityEngine.Random.Range(0, sprites.Length);

        return clothingNumber;
    }

    private void GetSpritesLists()
    {
        trendSprites = Resources.LoadAll<Sprite>("TrendSprites");
        shopSprites = Resources.LoadAll<Sprite>("ShopSprites");
        recyclingSprites = Resources.LoadAll<Sprite>("RecyclingSprites");
    }



}
