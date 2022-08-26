using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EndOfGame : MonoBehaviour
{
    [SerializeField] TMP_Text pointsEndOfGame;
    [SerializeField] MenuManager menuManager;
    [SerializeField] Timer cueTimer, trendTimer;
    [SerializeField] ArticleQueue article;
    [SerializeField] RandomQuote quote;


    private void Start()
    {
        GameStats.OnHealthChangedEvent += CheckEndOfGame;
    }

    void CheckEndOfGame(int points)
    {
        if(GameStats.GetHealth <= 0)
        {
            quote.NewQuote();
            menuManager.Pause();
            menuManager.OpenGameOverScreenImage();
            pointsEndOfGame.text = GameStats.GetPoints.ToString();
            GameStats.ResetGameStats();
            cueTimer.ResetValues();
            trendTimer.ResetValues();
            article.ClearQueue();
        }
    }
    void OnDestroy()
    {
        GameStats.OnHealthChangedEvent -= CheckEndOfGame;
    }
}
