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

public class ClothingFactory : MonoBehaviour
{
    private static int randomTrendPercentage;

    [SerializeField] 
    private static Sprite[] trendSprites, shopSprites, recyclingSprites;

    private static ClothingFactory _instance;
    public static ClothingFactory Instance { get { return _instance; } }

    

    private void Awake()
    {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(this.gameObject);
        }

    }    

    public static Clothing GetRandomclothing()
    {
        GetSpritesLists();
        //Sets a random clothingType
        var clothingType = (ClothingType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(ClothingType)).Length);
        var trendType = new TrendType();
        Sprite sprite = null;

        switch (clothingType)
        {
            case ClothingType.Shop:
                {
                    trendType = TrendType.None;
                    sprite = shopSprites[RandomizeClothingSprite(shopSprites)];
                    break;
                }
            case ClothingType.Trend:
                {
                    randomTrendPercentage = UnityEngine.Random.Range(1, 11);

                    if (randomTrendPercentage < 6)
                    {
                        // The enum type corresponding non-trend clothes it´s at the end of the list, that is why we substract 1 to the length of the enum
                        int trend = UnityEngine.Random.Range(0, Enum.GetNames(typeof(TrendType)).Length - 1);

                        trendType = (TrendType)trend;
                        sprite = trendSprites[trend];
                    }
                    else
                    {
                        trendType = TrendChanger.GetTrend;
                        sprite = trendSprites[(int)trendType];
                    }

                        break;
                }
            case ClothingType.Recycling:
                {
                    trendType  = TrendType.None;
                    sprite = recyclingSprites[RandomizeClothingSprite(recyclingSprites)];
                    break;
                }
        }
        return new Clothing(clothingType, trendType, sprite);
    }

    private static int RandomizeClothingSprite(Sprite[] sprites)
    {
        int clothingNumber = UnityEngine.Random.Range(0, sprites.Length);

        return clothingNumber;
    }

    private static void GetSpritesLists()
    {
        trendSprites = Resources.LoadAll<Sprite>("TrendSprites");
        shopSprites = Resources.LoadAll<Sprite>("ShopSprites");
        recyclingSprites = Resources.LoadAll<Sprite>("RecyclingSprites");
    }
}

[Serializable]
public class Clothing
{
    public ClothingType clothingType;
    public TrendType trendType;
    public Sprite sprite;

    public Clothing(ClothingType clothingType, TrendType trendType, Sprite sprite)
    {
        this.clothingType = clothingType;
        this.trendType = trendType;
        this.sprite = sprite;
    }
}
