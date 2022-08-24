using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArticleHolder : DragItem
{
    public Clothing data;
    RectTransform rect;

    public AnimationCurve animCurve;

    private void Start()
    {
        GetComponent<Image>().sprite = data.sprite;
        rect = GetComponent<RectTransform>();


        StartCoroutine(Animate(rect.sizeDelta, rect.rotation.eulerAngles.z, .5f));
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