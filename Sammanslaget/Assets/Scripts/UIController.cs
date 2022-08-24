using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text points, trend;
    [SerializeField] Image hearts;

    private void Update()
    {
        points.text = $"{GameStats.GetPoints}";
        hearts.fillAmount = GameStats.GetHealth / 3f;
        trend.text = $"{TrendChanger.GetTrend}";
    }

}
