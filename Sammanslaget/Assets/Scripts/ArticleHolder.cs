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
    ParticleSystem vfx;
    
    public int index = 0;
    [HideInInspector] public bool isTrend = false;

    bool vfxPlaying = false;

    void Start()
    {
        image = GetComponent<Image>();
        vfx = GetComponentInChildren<ParticleSystem>();
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
            vfx.Clear();
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

    public override void OnEndDrag(PointerEventData eventData)
    {
        Vector2 diff = rectTransform.anchoredPosition - transform.parent.GetComponent<RectTransform>().anchoredPosition;
        Debug.Log(diff);


        if(Mathf.Abs(diff.x) > Mathf.Abs(diff.y)) {
            if(Mathf.Abs(diff.x) < (Screen.width * .4f)) { base.OnEndDrag(eventData); return; }


            if(diff.x > 0) {
                CheckDeposit(ClothingType.Shop);
            }
            else {
                CheckDeposit(ClothingType.Recycling);
            }
        }

        if (Mathf.Abs(diff.y) < (Screen.height * .5f)) { base.OnEndDrag(eventData); return; }

        CheckDeposit(ClothingType.Trend);
    }

    public void CheckDeposit(ClothingType type)
    {
        if (data.clothingType == type) {
            if (type == ClothingType.Trend && data.trendType != TrendChanger.GetTrend && isTrend) {
                GameStats.RemoveHealth();
                Destroy(gameObject);
                return;
            }

            switch (type) {
                case ClothingType.Shop:
                    SoundManager.PlayRandomOneShot(new string[] { "shop1", "shop2", "shop3" });
                    break;
                case ClothingType.Trend:
                    SoundManager.PlayOneShot("trend1");
                    break;
                case ClothingType.Recycling:
                    SoundManager.PlayOneShot("recycle2");
                    break;
            }

            Destroy(gameObject);
            GameStats.AddPoint();
            return;
        }


        GameStats.RemoveHealth();

        Destroy(gameObject);
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