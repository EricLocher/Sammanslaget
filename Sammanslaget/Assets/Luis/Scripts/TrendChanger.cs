using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrendChanger : MonoBehaviour
{

    private static TrendChanger _instance;
    public static TrendChanger Instance { get { return _instance; } }
    public static TrendType GetTrend => currentTrend;

    static TrendType currentTrend;
    private int currentTrendNumber, randomTrendNumber;
    void Awake()
    {
        if (_instance == null) {
            _instance = this;
        }
        else {
            Destroy(this.gameObject);
        }
    }

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

}
