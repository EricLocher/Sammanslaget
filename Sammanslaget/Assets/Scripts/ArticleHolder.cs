using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArticleHolder : DragItem
{
    public Clothing data;
    RectTransform rect;
    Image image;
    public AnimationCurve animCurve;

    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = data.sprite;
        rect = GetComponent<RectTransform>();


        StartCoroutine(Animate(rect.sizeDelta, rect.rotation.eulerAngles.z, .5f));
    }

    void Update()
    {

        if(data.trendType == TrendChanger.GetTrend && data.clothingType == ClothingType.Trend) {
            image.color = new Color(.8f, .7f, .21f, 1);
        }
        else {
            image.color = new Color(1, 1, 1, 1);
        }
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        if (data.clothingType == ClothingType.Trend && data.trendType != TrendChanger.GetTrend)
            data.clothingType = ClothingType.Shop;

    }

    IEnumerator Animate(Vector2 size, float rotZ, float timeInSeconds)
    {
        rect.sizeDelta = Vector2.zero;

        float timeElapsed = 0;

        while (timeElapsed <= timeInSeconds) {
            yield return new WaitForEndOfFrame();
            timeElapsed += Time.deltaTime;

            rect.sizeDelta = size * animCurve.Evaluate(timeElapsed / timeInSeconds);
        }

        yield return null;
    }
}