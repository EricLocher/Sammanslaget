using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text points, trend, queue;
    [SerializeField] Image hearts;
    [SerializeField] ArticleQueue _queue;

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
    }

    void UpdateHealth(int points)
    {
        hearts.fillAmount = GameStats.GetHealth / 3f;
    }

    void OnDestroy()
    {
        GameStats.OnPointsChangedEvent -= UpdatePoints;
        GameStats.OnHealthChangedEvent -= UpdateHealth;
    }
}
