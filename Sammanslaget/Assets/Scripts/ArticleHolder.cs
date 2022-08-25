using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.VFX;

public class ArticleHolder : DragItem
{
    public Clothing data;
    public AnimationCurve animCurve;
    RectTransform rect;
    Image image;
    VisualEffect vfx;
    
    public int index = 0;
    [HideInInspector] public bool isTrend = false;

    bool vfxPlaying = false;

    void Start()
    {
        image = GetComponent<Image>();
        vfx = GetComponentInChildren<VisualEffect>();
        image.sprite = data.sprite;
        rect = GetComponent<RectTransform>();

        vfx.Stop();

        StartCoroutine(Animate(rect.sizeDelta, rect.rotation.eulerAngles.z, .5f));
    }

    void Update()
    {
        rect.position = new Vector3(rect.position.x, rect.position.y, -index);

        if(index != 0) { return; }
        if ((data.trendType == TrendChanger.GetTrend && data.clothingType == ClothingType.Trend) || isTrend) {
            if (!vfxPlaying) {
                vfx.Play();
                vfxPlaying = true;
            }
        }
        else {
            vfx.Stop();
        }
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        if (data.clothingType == ClothingType.Trend && data.trendType != TrendChanger.GetTrend)
            data.clothingType = ClothingType.Shop;
        else if((data.trendType == TrendChanger.GetTrend && data.clothingType == ClothingType.Trend))
            isTrend = true;
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