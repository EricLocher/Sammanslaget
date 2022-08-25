using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    [Header("Refrences")]
    [SerializeField] TMP_Text points, trend, queue;
    [SerializeField] Image hearts;
    [SerializeField] ArticleQueue _queue;

    [Header("Animations")]
    [SerializeField] AnimationCurve pointsAnimation;


    private void Start()
    {
        GameStats.OnPointsChangedEvent += UpdatePoints;
        GameStats.OnHealthChangedEvent += UpdateHealth;

        points.text = "";
        trend.text = "";
        queue.text = "";
    }

    private void Update()
    {
        trend.text = $"{TrendChanger.GetTrend}";
        queue.text = $"{_queue.GetCount()}";
    }

    void UpdatePoints(int points)
    {
        this.points.text = $"{points}";
        StartCoroutine(Animate(.5f, pointsAnimation, this.points.GetComponent<RectTransform>()));
    }

    void UpdateHealth(int points)
    {
        hearts.fillAmount = GameStats.GetHealth / 3f;
    }

    IEnumerator Animate(float t, AnimationCurve animCurve, RectTransform rect)
    {
        Vector2 size = rect.sizeDelta;
        rect.sizeDelta = Vector2.zero;

        float timeElapsed = 0;

        while (timeElapsed <= t) {
            yield return new WaitForEndOfFrame();
            timeElapsed += Time.deltaTime;

            rect.sizeDelta = size * animCurve.Evaluate(timeElapsed / t);
        }

        yield return null;
    }

    void OnDestroy()
    {
        GameStats.OnPointsChangedEvent -= UpdatePoints;
        GameStats.OnHealthChangedEvent -= UpdateHealth;
    }
}
