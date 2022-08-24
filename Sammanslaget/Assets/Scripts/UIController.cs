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

    private void Update()
    {
        points.text = $"{GameStats.GetPoints}";
        hearts.fillAmount = GameStats.GetHealth / 3f;
        trend.text = $"{TrendChanger.GetTrend}";
        queue.text = $"{_queue.GetCount()}";
    }

}
