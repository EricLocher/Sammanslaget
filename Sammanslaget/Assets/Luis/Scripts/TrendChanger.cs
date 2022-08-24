using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrendChanger : MonoBehaviour
{
    public TrendType currentTrend;
    private int currentTrendNumber, randomTrendNumber;

    [SerializeField] private TextMeshProUGUI trendText;

    private void Start()
    {
        ChangeCurrentTrend();
    }

    public void ChangeCurrentTrend()
    {
        do
        {
            randomTrendNumber = UnityEngine.Random.Range(0, Enum.GetNames(typeof(TrendType)).Length - 1);

        } while (currentTrendNumber == randomTrendNumber);

        currentTrendNumber = randomTrendNumber;

        currentTrend = (TrendType)currentTrendNumber;
    }

    public void ChangeTrendText()
    {
        trendText.text = currentTrend.ToString();
    }
}
