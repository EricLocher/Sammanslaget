using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text points, trend;
    [SerializeField] Image hearts;
    [SerializeField] ArticleQueue _queue;

    private void Start()
    {
        GameStats.OnPointsChangedEvent += UpdatePoints;
        GameStats.OnHealthChangedEvent += UpdateHealth;

        points.text = "0";
        trend.text = "";
    }

    private void Update()
    {
        trend.text = $"{TrendChanger.GetTrend}";
    }

    void UpdatePoints(int points)
    {
        this.points.text = $"{points}";
        this.points.GetComponent<Animator>().SetTrigger("PointsAnimation");
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
